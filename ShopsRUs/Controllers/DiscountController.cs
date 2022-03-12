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
    public class DiscountController : CustomBaseController
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var discounts = await _discountService.GetAllAsync();
            return CreateActionResultInstance(discounts);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DiscountDto discountDto)
        {
            var response = await _discountService.CreateAsync(discountDto);
            return CreateActionResultInstance(response);
        }
    }
}
