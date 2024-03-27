using Microsoft.AspNetCore.Http;
using Dietary.Base;
using Dietary.DataAccess.Entities;
using Dietary.Helpers;
using Dietary.DataAccess.Models;

namespace Dietary.DataAccess.Seeders
{
    public static class Seeder
    {
        public static async Task SeedFood(AppDbContext _appDbContext)
        {
            if (!_appDbContext.Set<FatSecretFood>().Any())
            {
                var foods = FoodSeed.GetSeeder();
                await _appDbContext.Set<Food>().AddRangeAsync(foods);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
