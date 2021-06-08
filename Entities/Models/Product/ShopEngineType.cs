using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Serializable]
    [Table("EngineType")]
    public class ShopEngineType
    {
        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "The name for the engine type is too long (maximum length 100 characters).")]
        public string Type { get; set; }

        public ICollection<ShopModel> ShopModels { get; set; }
    }

    partial class EntityTypeConfiguration : IEntityTypeConfiguration<ShopEngineType>
    {
        public void Configure(EntityTypeBuilder<ShopEngineType> e)
        {
            e.Property(t => t.Id).HasColumnName("engine_id");
            e.Property(t => t.Type).HasColumnName("engine_type");
        }

    }
}
