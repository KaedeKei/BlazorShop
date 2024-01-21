using BlazorShop.Models;

namespace BlazorShop.Data
{
    public interface ICatalogAsync
	{
		public Task AddProduct(Product product);
		Task <IReadOnlyCollection<Product>> GetProducts();
    }
}

