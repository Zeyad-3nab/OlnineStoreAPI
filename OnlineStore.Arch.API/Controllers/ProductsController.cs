using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Arch.Core.DTOs.ProductDTO;
using OnlineStore.Arch.Core.Helper;
using OnlineStore.Arch.Core.Services;
using OnlineStore.Arch.Core.Specifications;

namespace OnlineStore.Arch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices productServices;

        public ProductsController(IProductServices productServices)
        {
            this.productServices = productServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct([FromQuery]ProductSpecParams? productSpecParams) 
        {
            var result = await productServices.GetAllProductsAsync(productSpecParams);


            return Ok(result);
        }



        [HttpGet("brands")]
        public async Task<IActionResult> GetAllBrands()
        {
            var result = await productServices.GetAllBrandssAsync();
            return Ok(result);

        }


        [HttpGet("types")]
        public async Task<IActionResult> GetAllTypes()
        {
            var result = await productServices.GetAllTypesAsync();
            return Ok(result);

        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductById([FromRoute]int? id)
        {
            if (id is null) return BadRequest("Invalid Id"); 

            var result = await productServices.GetProductByIdAsync(id.Value);

            if (result is null) return NotFound("Product Not Found");
            return Ok(result);

        }
    }
}
