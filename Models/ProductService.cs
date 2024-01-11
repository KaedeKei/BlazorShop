using BlazorShop.Data;

namespace BlazorShop.Models
{
    public class ProductService
	{

        private readonly ICatalog _catalog;
        public ProductService(ICatalog catalog)
        {
            _catalog = catalog ?? throw new ArgumentNullException(nameof(catalog));
        }

        public IReadOnlyCollection<Product> GetProducts()
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                var products = _catalog.GetProducts();
                //var newProducts = new List<Product>(products.Count);
                var newProducts = products.Select(product => new Product(product.Id, product.Name, product.Price * 0.9m)).ToList();

				//foreach (var product in products)
                //{
                //    var newProduct = new Product(product.Id, product.Name, product.Price * 0.9m);
                //    newProducts.Add(newProduct);
                //}

                return newProducts;
            }
            else
            {
				return _catalog.GetProducts();
			}            
        }

    }
}
