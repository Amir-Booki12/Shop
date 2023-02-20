
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.OrderAgg;
using Shop.Domain.RoleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastucture.Persistent.Ef.RoleAgg
{
    internal class RoleCofiguration : IEntityTypeConfiguration<Role>
    {

        public void Configure(EntityTypeBuilder<Role> builder)
        {

            builder.ToTable("Roles", "role");
            builder.Property(b => b.RoleTitle)
                .HasMaxLength(50)
                .IsRequired();

            builder.OwnsMany(b => b.Permissions, option =>
            {
                option.ToTable("Permissions", "role");
                option.HasIndex(b => b.RoleId);

            });


        }
    }

}

