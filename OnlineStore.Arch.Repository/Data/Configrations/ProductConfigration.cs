using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Arch.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Arch.Repository.Data.Configrations
{
    public class ProductConfigration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(200);
            builder.Property(x => x.Name).IsRequired();

            builder.HasOne(e => e.ProductBrand)
                .WithMany()
                .HasForeignKey(e => e.BrandId)
                .OnDelete(DeleteBehavior.SetNull);


            builder.HasOne(e => e.ProductType)
               .WithMany()
               .HasForeignKey(e => e.TypeId)
               .OnDelete(DeleteBehavior.SetNull);



        }
    }
}
