using ShopsRUs.Dtos;
using ShopsRUs.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Services
{
    public interface IInvoiceService
    {

        Task<Response<List<InvoiceDto>>> GetAllAsync();
        Task<Response<InvoiceDto>> CreateAsync(InvoiceDto invoiceDto);
    }
}
