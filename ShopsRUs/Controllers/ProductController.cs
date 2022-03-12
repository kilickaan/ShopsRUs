using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRUs.Dtos;
using ShopsRUs.Services.Interfaces;
using ShopsRUs.Shared.ControllerBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : CustomBaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var products = await _productService.GetAllAsync();
            return CreateActionResultInstance(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            var response = await _productService.CreateAsync(productDto);
            return CreateActionResultInstance(response);
        }
    }
}
