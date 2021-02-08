using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }

        public DbSet<ShopModel> ShopModels { get; set; }
        public DbSet<ShopCarcaseType> shopCarcaseTypes { get; set; }
        public DbSet<ShopDriveType> shopDriveTypes { get; set; }
        public DbSet<ShopMark> shopMarks { get; set; }
        public DbSet<ShopEngineType> ShopEngineTypes { get; set; }
        public DbSet<ShopTransmissionType> shopTransmissionTypes { get; set; }
    }
}
