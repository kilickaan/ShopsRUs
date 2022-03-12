using ShopsRUs.Dtos;
using ShopsRUs.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<Response<List<CustomerDto>>> GetAllAsync();
        Task<Response<CustomerDto>> CreateAsync(CustomerDto customerDto);
    }
}
