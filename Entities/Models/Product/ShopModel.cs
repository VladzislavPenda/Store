using Entities.Models.Product;
using Entities.Models.Shop;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Entities.Models
{
    [Serializable]
    public class ShopModel
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public int? Year { get; set; }
        public int? HorsePower { get; set; }
        public int Price { get; set; }
        //public int MileAge { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int NumberOfCar { get; set; }
        public Guid StorageId { get; set; }
        public Storage Storage { get; set; }
        public ICollection<Mesh> Meshes { get; set; }
        public ICollection<Order> Orders { get; set; }
    }

    partial class EntityTypeConfiguration: IEntityTypeConfiguration<ShopModel>
    {
        public void Configure(EntityTypeBuilder<ShopModel> e)
        {
            e.Property(c => c.Id).HasColumnName("model_id");
            //e.Property(c => c.MileAge).HasColumnName("mile_age");
            e.Property(c => c.HorsePower).HasColumnName("horse_power");
            e.Property(c => c.Model).HasColumnName("model");
            e.Property(c => c.NumberOfCar).HasColumnName("number_of_car");
            e.Property(c => c.IsActive).HasColumnName("is_active");
            e.Property(c => c.StorageId).HasColumnName("storage_id");
            e.Property(c => c.Description).HasColumnName("description");
            e.Property(c => c.Year).HasColumnName("year");
            e.Property(c => c.Price).HasColumnName("price");
            e.HasOne(c => c.Storage).WithMany(c => c.ShopModels).HasForeignKey(c => c.StorageId);
        }
    }
}
