using DuongAppFirst.Data.EF.Extentions;
using DuongAppFirst.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DuongAppFirst.Data.EF.Configurations
{
    public class TagConfiguration : DbEntityConfiguration<Tag>
    {
        public override void Configure(EntityTypeBuilder<Tag> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(50).IsRequired()
           .IsUnicode(false).HasMaxLength(50);
            // etc.
        }
    }
}