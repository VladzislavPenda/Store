using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string UserEmail { get; set; }
        public DateTime OrderDateTime { get; set; }
        public Guid ShopModelId { get; set; }
        public ShopModel ShopModel { get; set; }
    }

    partial class EntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> e)
        {
            e.Property(e => e.Id).HasColumnName("id");
            e.Property(e => e.OrderDateTime).HasColumnName("creating_data");
            e.Property(e => e.UserEmail).HasColumnName("user_email");
            e.HasOne(c => c.ShopModel).WithMany(c => c.Orders).HasForeignKey(c => c.ShopModelId);
        }
    }
}
