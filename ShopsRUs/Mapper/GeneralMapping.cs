

using AutoMapper;
using ShopsRUs.Dtos;
using ShopsRUs.Models;

namespace ShopsRUs.Mapper
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Invoice, InvoiceDto>().ReverseMap();
            CreateMap<InvoiceLine, InvoiceLineDto>().ReverseMap();
            CreateMap<Discount, DiscountDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
