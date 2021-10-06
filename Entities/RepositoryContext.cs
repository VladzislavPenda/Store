using Entities.Configuration;
using Entities.Models;
using Entities.Models.Product;
using Entities.Models.Shop;
using Entities.Models.Views;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryContext).Assembly);
            modelBuilder.Entity<OrderStatistic>(e => {
                e.HasNoKey();
                e.ToView("orderStatsView");
            });
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }

        public DbSet<ShopModel> ShopModels { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatistic> OrderStatisticViews { get; set; }
        public DbSet<Ent> Ents { get; set; }
        public DbSet<Mesh> Meshes { get; set; }
        public DbSet<Storage> Storages { get; set; }
    }
}
