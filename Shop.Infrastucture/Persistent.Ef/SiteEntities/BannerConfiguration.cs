using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.SiteEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastucture.Persistent.Ef.SiteEntities
{
    internal class BannerConfiguration : IEntityTypeConfiguration<Banner>
    {
        public void Configure(EntityTypeBuilder<Banner> builder)
        {
            
            builder.Property(b => b.Link)
                .IsRequired();
            builder.Property(b => b.ImageName)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
