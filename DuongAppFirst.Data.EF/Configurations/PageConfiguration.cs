using DuongAppFirst.Data.EF.Extentions;
using DuongAppFirst.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DuongAppFirst.Data.EF.Configurations
{
    class PageConfiguration : DbEntityConfiguration<Page>
    {
        public override void Configure(EntityTypeBuilder<Page> entity)
        {

            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasMaxLength(50)
                                      .IsRequired();
        }

    }
}
