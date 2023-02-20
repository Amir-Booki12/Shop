using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastucture.Persistent.Ef.ProductAgg
{
    internal class PruductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "product");

            builder.HasIndex(b => b.Slug);

            builder.Property(b => b.Title)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(b => b.Slug)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(b => b.ImageName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(b => b.Description)
                .IsRequired();

            builder.OwnsMany(b => b.ProductImages, option =>
            {
                option.ToTable("ProductImages", "product");
                option.Property(b => b.ImageName)
                .HasMaxLength(100)
                .IsRequired();
            });

            builder.OwnsMany(b => b.ProductSpecifications, option =>
            {
                option.ToTable("Specifications", "product");
                option.Property(b => b.Key)
                .HasMaxLength(50)
                .IsRequired();

                option.Property(b => b.Value)
               .HasMaxLength(100)
               .IsRequired();
            });

            builder.OwnsOne(b => b.SeoData, config =>
            {
                config.Property(b => b.MetaDescription)
                    .HasMaxLength(500)
                    .HasColumnName("MetaDescription");

                config.Property(b => b.MetaTitle)
                    .HasMaxLength(500)
                    .HasColumnName("MetaTitle");

                config.Property(b => b.MetaKeyWords)
                    .HasMaxLength(500)
                    .HasColumnName("MetaKeyWords");

                config.Property(b => b.IndexPage)
                    .HasColumnName("IndexPage");

                config.Property(b => b.Canonical)
                    .HasMaxLength(500)
                    .HasColumnName("Canonical");

                config.Property(b => b.Schema)
                    .HasColumnName("Schema");
            });


        }
    }
}
