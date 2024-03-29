﻿using System.Net.Http.Headers;
using BlazorShop.Models;

namespace BlazorShop.Data
{
    public class InMemoryCatalog : ICatalog
    {
        private readonly List<Product> products = new()
        {
            new Product (1, "Чистый код", 1025),
            new Product (2, "Элегантные объекты", 985)
        };


        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public IReadOnlyCollection<Product> GetProducts()
        {
            return products;
        }

    }


}
