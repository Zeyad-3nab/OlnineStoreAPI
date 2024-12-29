using OnlineStore.Arch.Core.Models;
using OnlineStore.Arch.Repository.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnlineStore.Arch.Repository.Data
{
    public static class ApplicationDbContextSeed
    {
        public async static Task SeedAsync(ApplicationDbContext context) 
        {

            if (context.Brands.Count() == 0) 
            {
                //Read Data From JsonFile
                var BrandData = File.ReadAllText(@"..\OnlineStore.Arch.Repository\Data\DataSeed\brands.json");


                //Convert data to list
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandData);

                if (brands is not null && brands.Count > 0)
                {
                    await context.Brands.AddRangeAsync(brands);
                    context.SaveChanges();
                }
            }




            if (context.Types.Count() == 0)
            {
                //Read Data From JsonFile
                var TypeData = File.ReadAllText(@"..\OnlineStore.Arch.Repository\Data\DataSeed\types.json");


                //Convert data to list
                var types = JsonSerializer.Deserialize<List<ProductType>>(TypeData);

                if (types is not null && types.Count > 0)
                {
                    await context.Types.AddRangeAsync(types);
                    context.SaveChanges();
                }
            }





            if (context.products.Count() == 0)
            {
                //Read Data From JsonFile
                var ProductData = File.ReadAllText(@"..\OnlineStore.Arch.Repository\Data\DataSeed\products.json");


                //Convert data to list
                var products = JsonSerializer.Deserialize<List<Product>>(ProductData);

                if (products is not null && products.Count > 0)
                {
                    await context.products.AddRangeAsync(products);
                    context.SaveChanges();
                }
            }
        }
    }
}
