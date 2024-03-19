using Microsoft.EntityFrameworkCore;
using Dietary.Base;
using Dietary.DataAccess.Entities;
using Dietary.DataAccess.Extensions;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;

namespace Dietary.DataAccess
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IDataProtectionKeyContext
    {
        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var entitiesAssembly = typeof(User).Assembly;
            modelBuilder.RegisterAllEntities<BaseEntity>(entitiesAssembly);
        }
    }
}
