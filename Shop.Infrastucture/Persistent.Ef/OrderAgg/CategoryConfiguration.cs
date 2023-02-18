using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.OrderAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastucture.Persistent.Ef.OrderAgg
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders","order");

            builder.OwnsOne(b => b.Discount, option =>
            {
                option.Property(b => b.DiscountTitle)
                .HasMaxLength(50);
            });

            builder.OwnsOne(b => b.shippingMethod, option =>
            {
                option.Property(b => b.ShppingType)
                .HasMaxLength(50);
            });

            builder.OwnsMany(b => b.Items, option =>
            {
                option.ToTable("OrderItems", "order");
            });

            builder.OwnsOne(b => b.Addresses, option =>
            {
                option.ToTable("Addresses", "order");

                option.Property(b => b.City)
                .HasMaxLength(50)
                .IsRequired();

                option.Property(b => b.Family)
                .HasMaxLength(100)
                .IsRequired();

                option.Property(b => b.Shire)
                .HasMaxLength(50)
                .IsRequired();

                option.Property(b => b.PostAddress)
                .HasMaxLength(150)
                .IsRequired();

                option.Property(b => b.PostalCode)
                .HasMaxLength(50)
                .IsRequired();

                option.Property(b => b.NationalCode)
                .HasMaxLength(11)
                .IsRequired();

                option.Property(b => b.Name)
                .HasMaxLength(50)
                .IsRequired();

                option.Property(b => b.PhoneNumber)
                .HasMaxLength(11)
                .IsRequired();

            });
                
                
        }
    }
}
