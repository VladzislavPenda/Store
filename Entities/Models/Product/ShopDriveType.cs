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
    [Table("DriveType")]
    public class ShopDriveType
    {
        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "The name is too long (maximum length 100 characters.")]
        public string Type { get; set; }

        public ICollection<ShopModel> ShopModels { get; set; }
    }

    partial class EntityTypeConfiguration : IEntityTypeConfiguration<ShopDriveType>
    {
        public void Configure(EntityTypeBuilder<ShopDriveType> e)
        {
            e.Property(t => t.Id).HasColumnName("drive_id");
            e.Property(t => t.Type).HasColumnName("drive_type");
        }

    }
}
