using Microsoft.AspNetCore.Http;
using Dietary.Base;
using Dietary.DataAccess.Entities;
using Dietary.Helpers;
using Dietary.DataAccess.Models;

namespace Dietary.DataAccess.Seeders
{
    public static class Seeder
    {
        public static async Task Seed<TEntity, TSeed>(AppDbContext _appDbContext) where TEntity : BaseEntity where TSeed : IBaseSeed<TEntity>, new()
        {
            if (!_appDbContext.Set<TEntity>().Any())
            {
                var foods = new TSeed().GetSeeder();
                await _appDbContext.Set<TEntity>().AddRangeAsync(foods);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
