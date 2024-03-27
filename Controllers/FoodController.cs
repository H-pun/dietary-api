using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dietary.Base;
using Dietary.DataAccess.Entities;
using Dietary.DataAccess.Models.Constants;
using Dietary.DataAccess.Models;
using Dietary.DataAccess.Services;
using Compunet.YoloV8;
using Compunet.YoloV8.Plotting;
using SixLabors.ImageSharp;
using Dietary.DataAccess.Extensions;
using static Dietary.Helpers.FileHelper;
using Dietary.Helpers;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace Dietary.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    [ApiController]
    public class FoodController(ILogger<FoodController> logger, IFoodService service) : BaseController<
        CreateFoodRequest,
        UpdateFoodRequest,
        DetailFoodResponse,
        Food>(service)
    {
        private readonly ILogger<FoodController> _logger = logger;
        private readonly IFoodService _service = service;
        [HttpPost("predict")]
        public virtual async Task<ActionResult> Predict(IFormFile imgFile)
        {
            try
            {
                string baseDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                string fileName = imgFile.SetFileName(Guid.NewGuid().ToString());

                await UploadFileAsync(new()
                {
                    File = imgFile,
                    FilePath = $"predict/{fileName}"
                });

                string modelPath = Path.Combine(baseDir, "model", "best.onnx");
                string imgPath = Path.Combine(baseDir, "upload", "predict", fileName);
                string plotPath = Path.Combine(baseDir, "upload", "predict", $"plot-{fileName}");

                using var predictor = YoloV8Predictor.Create(modelPath);
                var result = await predictor.DetectAsync(imgPath);

                var detectedFood = result.Boxes.Select(box => box.Class.Name.ToTitleCase()).Distinct().ToList();
                List<DetailFoodResponse> foods = [.. _service.GetAll<DetailFoodResponse>(food => detectedFood.Any(name => name == food.Name))];
                DetailPredictResponse predictResult = new()
                {
                    Foods = result.Boxes.Select(box => new PredictedFood
                    {
                        FoodDetail = foods.Where(x => x.ModelName == box.Class.Name.ToTitleCase()).FirstOrDefault(),
                        PredictResult = new(box)
                    }).ToList(),
                    ProcessTime = result.Speed,
                };

                if (System.IO.File.Exists(imgPath))
                {
                    // System.IO.File.Delete(imgPath);
                    // _logger.LogInformation("File Deleted!");
                    _logger.LogInformation(imgPath);
                }

                using var image = Image.Load(imgPath);
                _logger.LogInformation(image.ToString());
                using var ploted = await result.PlotImageAsync(image);
                ploted.Save(plotPath);

                if (result.Boxes.Length == 0)
                    throw new HttpRequestException("No food detected!", null, HttpStatusCode.BadRequest);

                return new SuccessApiResponse(string.Format(MessageConstant.Success), predictResult);
            }
            catch (HttpRequestException ex)
            {
                return new ErrorApiResponse(ex.Message, statusCode: (int)ex.StatusCode);
            }
            catch (Exception ex)
            {
                return new ErrorApiResponse(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
    }
}
