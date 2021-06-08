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
    [Table("Mark")]
    public class ShopMark
    {
        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "The name of the car brand is too long (maximum length 100 characters).")]
        public string Name { get; set; }

        [StringLength(100, ErrorMessage = "Manufacturer country name too long (maximum length 100 characters).")]
        public string Country { get; set; }

        public ICollection<ShopModel> ShopModels { get; set; }
    }

    partial class EntityTypeConfiguration: IEntityTypeConfiguration<ShopMark>
    {
        public void Configure(EntityTypeBuilder<ShopMark> e)
        {
            e.Property(t => t.Id).HasColumnName("mark_id");
            e.Property(t => t.Name).HasColumnName("mark_name");
            e.Property(t => t.Country).HasColumnName("producing_country");
        }
    }
}
