
using AutoMapper;
using Demo_App.Data;
using Demo_App.Model.Domain;
using Demo_App.Model.Dto;
using Demo_App.Repositories;
using Demo_App.Validate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        //Injection in the program.cs
        private readonly IProductRep productRep;
        private readonly IMapper mapper;

        public ProductController(IProductRep productRep, IMapper mapper)
        {
            this.productRep = productRep;
            this.mapper=mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Products = await productRep.GetAllAsync();
            //manual mapping
            /*var productDot=new List<ProductDto>();
            foreach(var products in Products)
            {
                productDot.Add(new ProductDto()
                {
                    Id= products.Id,
                    Name= products.Name,
                    Description= products.Description,
                    price=products.price
                });
            }*/
            //automapping
            var productDot=mapper.Map<List<ProductDto>>(Products);

            return Ok(productDot);
        }
        [HttpPost]
        [ValidateModelAttribuate]
        public async Task< IActionResult> Create([FromBody] AddProductRequestDto addProductDto)
        {
            var ProductModel = mapper.Map<Product>(addProductDto);
            var productmodel=await productRep.CreateAsync(ProductModel);
            var productDto = mapper.Map<ProductDto>(productmodel);
            return Ok(productDto);
        }
    }
}
