using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Product
{
    public class Mesh
    {
        public Guid ModelId { get; set; }
        public ShopModel ShopModel { get; set; }
        public Guid EntId { get; set; }
        public Ent Ent { get; set; }
    }
    partial class EntityTypeConfiguration : IEntityTypeConfiguration<Mesh>
    {
        public void Configure(EntityTypeBuilder<Mesh> e)
        {
            e.Property(m => m.ModelId).HasColumnName("model_id");
            e.Property(m => m.EntId).HasColumnName("ent_id");
            e.HasKey(m => new { m.ModelId, m.EntId });
            e.HasOne(m => m.ShopModel).WithMany(m => m.Meshes).HasForeignKey(m => m.ModelId);
            e.HasOne(m => m.Ent).WithMany(m => m.Meshes).HasForeignKey(m => m.EntId);
        }
    }
}
