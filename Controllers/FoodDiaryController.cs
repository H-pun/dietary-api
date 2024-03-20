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

namespace Dietary.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FoodDiaryController(ILogger<FoodDiaryController> logger, IFoodDiaryService service) : BaseController<
        CreateFoodDiaryRequest,
        UpdateFoodDiaryRequest,
        DetailFoodDiaryResponse,
        FoodDiary>(service)
    {
        private readonly ILogger<FoodDiaryController> _logger = logger;
        private readonly IFoodDiaryService _service = service;

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
                // string plotPath = Path.Combine(baseDir, "upload", "predict", $"plot-{fileName}");

                using var predictor = YoloV8Predictor.Create(modelPath);

                var result = await predictor.DetectAsync(imgPath);

                using var image = Image.Load(imgPath);

                // using var ploted = await result.PlotImageAsync(image);
                // ploted.Save(plotPath);

                if (System.IO.File.Exists(imgPath))
                {
                    System.IO.File.Delete(imgPath);
                    _logger.LogInformation("File Deleted!");
                }

                return new SuccessApiResponse(string.Format(MessageConstant.Success), result);

            }
            catch (Exception ex)
            {
                return new ErrorApiResponse(ex.InnerException == null ? ex.Message : ex.InnerException.Message,
                new
                {
                    OuterException = ex.Message,
                    InnerException = ex.InnerException.Message,
                });
            }
        }
        [HttpGet("user")]
        public virtual ActionResult<List<DetailFoodDiaryResponse>> GetByIdUser(Guid idUser, DateTime? date)
        {
            try
            {
                List<DetailFoodDiaryResponse> model = _baseService.GetAll<DetailFoodDiaryResponse>(x => x.IdUser == idUser && (!date.HasValue || x.AddedAt.Date == date.Value.Date));
                return new SuccessApiResponse(string.Format(MessageConstant.Success), model);
            }
            catch (Exception ex)
            {
                return new ErrorApiResponse(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }

        public override Task<ActionResult> Create([FromForm] CreateFoodDiaryRequest model)
        {
            return base.Create(model);
        }
    }
}
