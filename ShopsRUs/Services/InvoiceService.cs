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
            try
            {
                var invoices = await _invoiceCollection.Find(invoice => true).ToListAsync();

                return Response<List<InvoiceDto>>.Success(_mapper.Map<List<InvoiceDto>>(invoices), 200);
            }
            catch (Exception ex)
            {
                return Response<List<InvoiceDto>>.Fail("Error Message: " + ex.Message, 500);
            }
        }

        public async Task<Response<InvoiceDto>> CreateAsync(InvoiceDto invoiceDto)
        {
            try
            {
                var invoice = _mapper.Map<Invoice>(invoiceDto);

                var customer = await _customerCollection.Find<Customer>(x => x.Id == invoice.CustomerId).FirstAsync();

                var discount = await _discountCollection.Find<Discount>(x => x.Id == customer.UserTypeId).FirstAsync();

                var products = await _productCollection.Find(product => true).ToListAsync();

                double TotalAmount = 0.0;
                double totalDiscount = 0.0;

                foreach (var line in invoice.InvoiceLine)
                {
                    foreach (var product in products)
                    {
                        if (product.Id == line.ProductId)
                        {
                            double quantity = Convert.ToDouble(line.Quantity);

                            if (quantity > 0)
                            {
                                double price = 0;
                                double discountAmount = 0;
                                double lineAmount = 0;

                                //There is no discount for groceries
                                if (product.ProductType == (int)Enums.ProductType.Groceries)
                                {

                                    price = product.ProductPrice;
                                    discountAmount = 0.0;

                                    lineAmount = quantity * price;
                                    totalDiscount += 0;
                                    TotalAmount += lineAmount;
                                    totalDiscount += 0;
                                }
                                else if (product.ProductType == (int)Enums.ProductType.Others) //Others have discount types
                                {

                                    if (discount.DiscountType == (int)Enums.UserTypes.Employee) // 30% Discount
                                    {

                                        discountAmount = product.ProductPrice * discount.DiscountRate / 100;
                                        price = product.ProductPrice - discountAmount;
                                    }
                                    else if (discount.DiscountType == (int)Enums.UserTypes.Affiliate) // 10% Discount
                                    {
                                        discountAmount = product.ProductPrice * discount.DiscountRate / 100;
                                        price = product.ProductPrice - discountAmount;
                                    }
                                    else if (discount.DiscountType == (int)Enums.UserTypes.Customer)
                                    {
                                        if (customer.CreatedOn.AddYears(2) < DateTime.Now)
                                        {

                                            discount.DiscountRate = 5;
                                            discountAmount = product.ProductPrice * 5 / 100;
                                            price = product.ProductPrice - discountAmount;
                                        }
                                        else
                                        {
                                            int multiplier = Convert.ToInt32(product.ProductPrice) / 100;
                                            if (multiplier > 0)
                                            {
                                                discount.DiscountRate = multiplier * 5;
                                                discountAmount = product.ProductPrice * multiplier * 5 / 100;
                                                price = product.ProductPrice - discountAmount;
                                            }
                                        }

                                    }

                                    lineAmount = quantity * price;
                                    TotalAmount += lineAmount;
                                    totalDiscount += quantity * discountAmount;
                                }
                                else
                                {
                                    return Response<InvoiceDto>.Fail("Wrong Product Type Value", 404);
                                }
                            }
                            else
                            {
                                return Response<InvoiceDto>.Fail("Wrong Quantity Value", 404);
                            }
                        }
                    }
                }


                invoice.PayableAmount = Math.Round(TotalAmount, 2);

                invoice.AllowanceAmount = Math.Round(totalDiscount, 2);

                invoice.AllowancePercentage = Math.Round(totalDiscount / (TotalAmount + totalDiscount) * 100, 2);

                await _invoiceCollection.InsertOneAsync(invoice);

                return Response<InvoiceDto>.Success(_mapper.Map<InvoiceDto>(invoice), 200);
            }
            catch (Exception ex)
            {
                return Response<InvoiceDto>.Fail("Error Message: " + ex.Message, 500);
            }
        }

    }
}
