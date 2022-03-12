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
    public class DiscountService : IDiscountService
    {
        private readonly IMongoCollection<Discount> _discountCollection;
        private readonly IMapper _mapper;

        public DiscountService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionStrings);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _discountCollection = database.GetCollection<Discount>(databaseSettings.DiscountCollectionName);

            _mapper = mapper;
        }

        public async Task<Response<List<DiscountDto>>> GetAllAsync()
        {
            var discounts = await _discountCollection.Find(discount => true).ToListAsync();

            return Response<List<DiscountDto>>.Success(_mapper.Map<List<DiscountDto>>(discounts), 200);
        }

        public async Task<Response<DiscountDto>> CreateAsync(DiscountDto discountDto)
        {
            var discount = _mapper.Map<Discount>(discountDto);
            await _discountCollection.InsertOneAsync(discount);

            return Response<DiscountDto>.Success(_mapper.Map<DiscountDto>(discount), 200);
        }


    }
}
