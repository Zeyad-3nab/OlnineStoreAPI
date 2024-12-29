using OnlineStore.Arch.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Arch.Core.Specifications.Products
{
    public class ProductSpecifications:BaseSpecification<Product , int>
    {
        public ProductSpecifications(int id):base(p=>p.Id==id)
        {
            
        }

        public ProductSpecifications(ProductSpecParams productSpecParams):base(
            p=> 
            (string.IsNullOrEmpty(productSpecParams.Search) || p.Name.ToLower().Contains(productSpecParams.Search))
            &&
            (!productSpecParams.BrandId.HasValue || p.BrandId==productSpecParams.BrandId)
            &&
            (!productSpecParams.TypeId.HasValue || p.TypeId==productSpecParams.TypeId))
        {
            if (!string.IsNullOrEmpty(productSpecParams.Sort))
            {
                switch (productSpecParams.Sort) 
                {
                    case "priceAsc":

                        OrderBy=p=>p.Price;
                        break;

                    case "priceDesc":

                        OrderByDescending = p => p.Price;
                        break;

                    default :
                        OrderBy = p => p.Name;
                        break;
                }
            }
            else 
            {
                OrderBy = p => p.Name;
            }


            Includes.Add(p => p.ProductBrand);
            Includes.Add(p => p.ProductType);



            ApplyPagination(productSpecParams.PageSize * (productSpecParams.PageIndex - 1), productSpecParams.PageSize);
        }
    }

}
