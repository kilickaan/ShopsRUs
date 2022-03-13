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
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionStrings);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);

            _mapper = mapper;
        }

        public async Task<Response<List<ProductDto>>> GetAllAsync()
        {
            try
            {
                var products = await _productCollection.Find(product => true).ToListAsync();

                return Response<List<ProductDto>>.Success(_mapper.Map<List<ProductDto>>(products), 200);
            }
            catch (Exception ex)
            {

                return Response<List<ProductDto>>.Fail("Error Message: " + ex.Message, 500);
            }
        }

        public async Task<Response<ProductDto>> CreateAsync(ProductDto productDto)
        {
            try
            {
                var product = _mapper.Map<Product>(productDto);
                await _productCollection.InsertOneAsync(product);

                return Response<ProductDto>.Success(_mapper.Map<ProductDto>(product), 200);
            }
            catch (Exception ex)
            {

                return Response<ProductDto>.Fail("Error Message: " + ex.Message, 500);
            }
        }
    }
}
