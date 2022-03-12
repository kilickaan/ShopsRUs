using AutoMapper;
using ShopsRUs.Dtos;
using ShopsRUs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Mapper
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Invoice, InvoiceDto>().ReverseMap();
        }
    }
}
