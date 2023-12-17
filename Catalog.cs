using System.Net.Http.Headers;

namespace BlazorShop
{
	public class Catalog
	{
		private readonly List<Product> _products = new()
		{
			new Product (1, "Чистый код", 1025),
			new Product (2, "Элегантные объекты", 985)
		};

		public Product[] GetProducts()
		{
			return _products.ToArray();		
		}

		public void AddProduct(Product product)
		{
			_products.Add(product);
		}
	}

	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }

		public Product(int id, string name, decimal price)
		{
			Id = id;
			Name = name;
			Price = price;
		}
	}
}
