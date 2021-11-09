using DuongAppFirst.Data.EF.Extentions;
using DuongAppFirst.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DuongAppFirst.Data.EF.Configurations
{
    public class SystemConfigConfiguration : DbEntityConfiguration<SystemConfig>
    {
        public override void Configure(EntityTypeBuilder<SystemConfig> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(255)
                                      .IsRequired()
                                      ;
        }
    }
}