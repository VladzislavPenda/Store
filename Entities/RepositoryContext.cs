﻿using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ShopModel> ShopModels { get; set; }
        public DbSet<ShopCarcaseType> shopCarcaseTypes { get; set; }
        public DbSet<ShopDriveType> shopDriveTypes { get; set; }
        public DbSet<ShopMark> shopMarks { get; set; }
        public DbSet<ShopEngineType> ShopEngineTypes { get; set; }
        public DbSet<ShopTransmissionType> shopTransmissionTypes { get; set; }
    }
}
