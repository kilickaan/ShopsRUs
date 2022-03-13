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
    public class CustomerService : ICustomerService
    {
        private readonly IMongoCollection<Customer> _customerCollection;
        private readonly IMapper _mapper;

        public CustomerService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionStrings);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _customerCollection = database.GetCollection<Customer>(databaseSettings.CustomerCollectionName);

            _mapper = mapper;
        }

        public async Task<Response<List<CustomerDto>>> GetAllAsync()
        {
            try
            {
                var customers = await _customerCollection.Find(customer => true).ToListAsync();

                return Response<List<CustomerDto>>.Success(_mapper.Map<List<CustomerDto>>(customers), 200);
            }
            catch (Exception ex)
            {
                return Response<List<CustomerDto>>.Fail("Error Message: " + ex.Message, 500);
            }
        }

        public async Task<Response<CustomerDto>> CreateAsync(CustomerDto customerDto)
        {
            try
            {
                var customer = _mapper.Map<Customer>(customerDto);
                await _customerCollection.InsertOneAsync(customer);

                return Response<CustomerDto>.Success(_mapper.Map<CustomerDto>(customer), 200);
            }
            catch (Exception ex)
            {
                return Response<CustomerDto>.Fail("Error Message: " + ex.Message, 500);
            }

        }
    }
}
