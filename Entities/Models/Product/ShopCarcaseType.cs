using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Serializable]
    [Table("CarcaseType")]
    public class ShopCarcaseType
    {
        public int Id { get; set; }

        
        [StringLength(100, ErrorMessage = "The name is too long (maximum 100 characters).")]
        public string Type { get; set; }

        public ICollection<ShopModel> ShopModels { get; set; }
    }

    partial class EntityTypeConfiguration : IEntityTypeConfiguration<ShopCarcaseType>
    {
        public void Configure(EntityTypeBuilder<ShopCarcaseType> e)
        {
            e.Property(t => t.Id).HasColumnName("carcase_id");
            e.Property(t => t.Type).HasColumnName("carcase_type");
        }

    }
}
