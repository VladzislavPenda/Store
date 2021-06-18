using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Entities.Models.Shop
{
    public class Storage
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
        public ICollection<ShopModel> ShopModels { get; set; }
    }
    partial class EntityTypeConfiguration : IEntityTypeConfiguration<Storage>
    {
        public void Configure(EntityTypeBuilder<Storage> e)
        {
            e.Property(c => c.Id).HasColumnName("id");
            e.Property(c => c.Address).HasColumnName("storage_address");
            e.Property(c => c.OpenTime).HasColumnName("open_time");
            e.Property(c => c.CloseTime).HasColumnName("close_time");
        }
    }
}
