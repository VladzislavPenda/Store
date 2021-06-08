using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(RepositoryContext).Assembly);

            base.OnModelCreating(builder);
            //builder.ApplyConfiguration(new RoleConfiguration());

        }

        public DbSet<ShopModel> ShopModels { get; set; }
        public DbSet<ShopCarcaseType> ShopCarcaseTypes { get; set; }
        public DbSet<ShopDriveType> ShopDriveTypes { get; set; }
        public DbSet<ShopMark> ShopMarks { get; set; }
        public DbSet<ShopEngineType> ShopEngineTypes { get; set; }
        public DbSet<ShopTransmissionType> ShopTransmissionTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CarShop> CarShops { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Profession> Professions { get; set; }
    }
}
