using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Views
{
    public class OrderStatistic
    {
        public int EntType { get; set; }
        public string Value { get; set; }
        public int Count { get; set; }
    }

    partial class EntityTypeConfiguration : IEntityTypeConfiguration<OrderStatistic>
    {
        public void Configure(EntityTypeBuilder<OrderStatistic> e)
        {
            e.Property(c => c.EntType).HasColumnName("ent_type");
            e.Property(c => c.Value).HasColumnName("value");
            e.Property(c => c.Count).HasColumnName("ents_count");
        }
    }
}
