using OnlineStore.Arch.Core.DTOs.ProductDTO;
using OnlineStore.Arch.Core.Helper;
using OnlineStore.Arch.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Arch.Core.Services
{
    public interface IProductServices
    {
        Task<PaginationResponce<ProductDTO>> GetAllProductsAsync(ProductSpecParams productSpecParams);
        Task<IEnumerable<TypeBrandDTO>> GetAllTypesAsync();
        Task<IEnumerable<TypeBrandDTO>> GetAllBrandssAsync();
        Task<ProductDTO> GetProductByIdAsync(int id);
    }
}
