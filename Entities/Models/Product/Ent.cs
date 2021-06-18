using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Entities.Models.Product
{
    public class Ent
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Type { get; set; }
        public ICollection<Mesh> Meshes { get; set; }

    }
    partial class EntityTypeConfiguration : IEntityTypeConfiguration<Ent>
    {
        public void Configure(EntityTypeBuilder<Ent> e)
        {
            e.Property(t => t.Id).HasColumnName("id");
            e.Property(t => t.Value).HasColumnName("value");
            e.Property(t => t.Type).HasColumnName("ent_type");
        }
    }
}
