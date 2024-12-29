using AutoMapper;
using OnlineStore.Arch.Core.DTOs.ProductDTO;
using OnlineStore.Arch.Core.Helper;
using OnlineStore.Arch.Core.IRepositories;
using OnlineStore.Arch.Core.Models;
using OnlineStore.Arch.Core.Services;
using OnlineStore.Arch.Core.Specifications;
using OnlineStore.Arch.Core.Specifications.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Arch.Services.Services.Products
{
    public class ProductServices : IProductServices
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public ProductServices(IUnitOfWork unitOfWork ,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
        }




        public async Task<PaginationResponce<ProductDTO>> GetAllProductsAsync(ProductSpecParams productSpecParams)
        {
            var spec = new ProductSpecifications(productSpecParams);

            var products = await unitOfWork.Repository<Product, int>().GetAllWithSpecAsync(spec);
            var mappedProduct = _mapper.Map<IEnumerable<ProductDTO>>(products);
            var countSpec= new ProductWithCountSpecification(productSpecParams);

            var count = await unitOfWork.Repository<Product, int>().GetCountAsync(countSpec);

            return new PaginationResponce<ProductDTO>(productSpecParams.PageSize, productSpecParams.PageIndex, count , mappedProduct);
        }


        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            var spec = new ProductSpecifications(id);

            return _mapper.Map<ProductDTO>(await unitOfWork.Repository<Product, int>().GetByIdWithSpecAsync(spec));
        }



        public async Task<IEnumerable<TypeBrandDTO>> GetAllBrandssAsync()
        {
            return _mapper.Map<IEnumerable<TypeBrandDTO>>(await unitOfWork.Repository<ProductBrand, int>().GetAllAsync());

        }




        public async Task<IEnumerable<TypeBrandDTO>> GetAllTypesAsync()
        {

            return  _mapper.Map<IEnumerable<TypeBrandDTO>>(await unitOfWork.Repository<ProductType, int>().GetAllAsync());
        }
    }
}
