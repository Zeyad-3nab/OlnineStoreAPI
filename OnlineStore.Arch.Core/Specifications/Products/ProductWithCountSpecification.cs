using OnlineStore.Arch.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Arch.Core.Specifications.Products
{
    public class ProductWithCountSpecification : BaseSpecification<Product, int>
    {
        public ProductWithCountSpecification(ProductSpecParams productSpecParams) : base(
           p =>
           (string.IsNullOrEmpty(productSpecParams.Search) || p.Name.ToLower().Contains(productSpecParams.Search))
           &&
           (!productSpecParams.BrandId.HasValue || p.BrandId == productSpecParams.BrandId)
           &&
           (!productSpecParams.TypeId.HasValue || p.TypeId == productSpecParams.TypeId))
        {
        }
    }
}
