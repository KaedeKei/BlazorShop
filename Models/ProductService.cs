using BlazorShop.Data;

namespace BlazorShop.Models
{
    public class ProductService
	{
        private readonly ICatalogAsync _catalog;
        public ProductService(ICatalogAsync catalog)
        {
            _catalog = catalog ?? throw new ArgumentNullException(nameof(catalog));
        }

        public async Task <IReadOnlyCollection<Product>> GetProducts()
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
            {
				var products = await _catalog.GetProducts();

				IReadOnlyCollection<Product> newProducts = new List<Product>(products.Count);
				newProducts = products.Select(product => new Product(product.Id, product.Name, product.Price * 0.9m)).ToList();

				//foreach (var product in products)
				//{
				//    var newProduct = new Product(product.Id, product.Name, product.Price * 0.9m);
				//    newProducts.Add(newProduct);
				//}

				return newProducts;
			}
			else
            {
                return await _catalog.GetProducts();
            }
        }
    }
}
