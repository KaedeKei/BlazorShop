﻿using System.Text.Json;
using BlazorShop.Models;

namespace BlazorShop.Data
{
    public class InJsonFileCatalog : ICatalog
    {

        private readonly string filePath;

        public InJsonFileCatalog(string filePath)
        {
            this.filePath = filePath;
        }

        public IReadOnlyCollection<Product> GetProducts()
        {
            if (!File.Exists(filePath))
            {
                return new List<Product>();
            }

            var json = File.ReadAllText(filePath);
            var products = JsonSerializer.Deserialize<List<Product>>(json);
            return products ?? new List<Product>();
        }


        public void AddProduct(Product product)
        {
            var products = GetProducts().ToList();
            products.Add(product);
            var json = JsonSerializer.Serialize(products);
            File.WriteAllText(filePath, json);
        }
    }
}
