ShopsRUs API
======================


## Requirements 
________
````
AutoMapper
Mongo.Driver
MongoDB Compass
Visual Studio 2019 (.Net Core 5)
````

## Usage 
________
- Clone repository and Open the Project 
- After restore process, run API
- Add DiscountTypes via Swagger
````
{
  "discountType": 1,
  "discountRate": 30
}
````
````
{
  "discountType": 2,
  "discountRate": 10
}
````
````
{
  "discountType": 3,
  "discountRate": 0
}
````
- Add Grocery Product via Swagger
````
{
  "productName": "Chocolate",
  "productPrice": 1500,
  "productType": 1
}
````
- Add Others Product via Swagger
````
{
  "productName": "Laptop",
  "productPrice": 1000,
  "productType": 0 
}
````
- Add Customer via Swagger
````
{
  "username": "Iron Man",
  "password": "TonyStark",
  "userTypeId": "Write the discountId here (Find it from DiscountCollection)",
  "createdOn": "2022-03-13T12:07:37.439Z"
}
````
- Add Invoice using CustomerId and ProductIds (Dont forget to add quantity of the product)
````
{
  "invoiceId": "ABC202200000000001",
  "customerId": "Write the customerId here (Find it from CustomerCollection)",
  "allowanceAmount": 0,
  "allowancePercentage": 0,
  "payableAmount": 0,
  "createdOn": "2022-03-13T12:11:41.175Z",
  "invoiceLine": [
    {
      "productId": "Write the ProductId here (Find it from ProductCollection)",
      "quantity": 0
    }
  ]
}
````
Sample Output :
````
{
  "data": [
    {
      "id": "622dca758e0d354410ee4f7c",
      "invoiceId": "ABC202200000000001",
      "customerId": "622dbecba540110287d21952",
      "allowanceAmount": 2500,
      "allowancePercentage": 26.32,
      "payableAmount": 7000,
      "createdOn": "2022-03-13T10:40:51.779Z",
      "invoiceLine": [
        {
          "productId": "622cf31427279d0aa14b64ea",
          "quantity": 3
        },
        {
          "productId": "622cffafd133b81e7a84d0eb",
          "quantity": 5
        }
      ]
    }
  ],
  "errors": null
}
