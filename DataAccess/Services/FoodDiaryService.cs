using Compunet.YoloV8;
using Compunet.YoloV8.Plotting;
using Dietary.Base;
using Dietary.DataAccess.Entities;
using Dietary.DataAccess.Models;
using Dietary.Helpers;
using SixLabors.ImageSharp;

namespace Dietary.DataAccess.Services
{
    public interface IFoodDiaryService : IBaseService<FoodDiary>
    {

    }
    public class FoodDiaryService(AppDbContext appDbContext) : BaseService<FoodDiary>(appDbContext), IFoodDiaryService
    {
        // public override async Task<FoodDiary> Create<TModel>(TModel model)
        // {
        //     FoodDiary entity = model.MapToEntity<FoodDiary>();

        //     await _appDbContext.Set<FoodDiary>().AddAsync(entity);
        //     await _appDbContext.SaveChangesAsync();

        //     await FileHelper.UploadFileAsync(entity.GetFileInfo());

        //     string[] dir = entity.GetFileInfo().FilePath.Split('/');

        //     string modelPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "model", "best.onnx");
        //     string imgPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload", entity.GetFileInfo().FilePath);
        //     string plotPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload", dir[0], $"plot-{dir[1]}");

        //     using var predictor = YoloV8Predictor.Create(modelPath);

        //     var result = await predictor.DetectAsync(imgPath);

        //     using var image = Image.Load(imgPath);
        //     using var ploted = await result.PlotImageAsync(image);

        //     ploted.Save(plotPath);

        //     return entity;
        // }
    }
}
