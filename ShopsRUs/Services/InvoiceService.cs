using AutoMapper;
using MongoDB.Driver;
using ShopsRUs.Dtos;
using ShopsRUs.Models;
using ShopsRUs.Services.Interfaces;
using ShopsRUs.Settings;
using ShopsRUs.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IMongoCollection<Invoice> _invoiceCollection;
        private readonly IMongoCollection<Discount> _discountCollection;
        private readonly IMongoCollection<Customer> _customerCollection;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;

        public InvoiceService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionStrings);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _invoiceCollection = database.GetCollection<Invoice>(databaseSettings.InvoiceCollectionName);
            _discountCollection = database.GetCollection<Discount>(databaseSettings.DiscountCollectionName);
            _customerCollection = database.GetCollection<Customer>(databaseSettings.CustomerCollectionName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);

            _mapper = mapper;
        }

        public async Task<Response<List<InvoiceDto>>> GetAllAsync()
        {
            var invoices = await _invoiceCollection.Find(invoice => true).ToListAsync();

            return Response<List<InvoiceDto>>.Success(_mapper.Map<List<InvoiceDto>>(invoices), 200);
        }

        public async Task<Response<InvoiceDto>> CreateAsync(InvoiceDto invoiceDto)
        {
            var invoice = _mapper.Map<Invoice>(invoiceDto);

            //var product = await

            var customer = await _customerCollection.Find<Customer>(x => x.Id == invoice.CustomerId).FirstAsync();

            var discount = await _discountCollection.Find<Discount>(x => x.Id == customer.UserTypeId).FirstAsync();

            var discountAmount = invoice.PayableAmount * discount.DiscountRate / 100;

            invoice.PayableAmount = Convert.ToDouble(invoice.PayableAmount) - Convert.ToDouble(discountAmount);

            invoice.AllowanceAmount = discountAmount;

            await _invoiceCollection.InsertOneAsync(invoice);

            return Response<InvoiceDto>.Success(_mapper.Map<InvoiceDto>(invoice), 200);
        }

    }
}
