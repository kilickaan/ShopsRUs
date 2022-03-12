using AutoMapper;
using MongoDB.Driver;
using ShopsRUs.Dtos;
using ShopsRUs.Models;
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
        private readonly IMapper _mapper;

        public InvoiceService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _invoiceCollection = database.GetCollection<Invoice>(databaseSettings.InvoiceCollectionName);

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
            await _invoiceCollection.InsertOneAsync(invoice);

            return Response<InvoiceDto>.Success(_mapper.Map<InvoiceDto>(invoice), 200);
        }

    }
}
