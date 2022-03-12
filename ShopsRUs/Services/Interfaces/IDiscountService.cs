using ShopsRUs.Dtos;
using ShopsRUs.Models;
using ShopsRUs.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Services.Interfaces
{
    public interface IDiscountService 
    {
        Task<Response<List<DiscountDto>>> GetAllAsync();
        Task<Response<DiscountDto>> CreateAsync(DiscountDto discountDto);
    }
}
