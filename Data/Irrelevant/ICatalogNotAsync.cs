using BlazorShop.Models;

namespace BlazorShop.Data.Irrelevant
{
    public interface ICatalogNotAsync
    {
        public void AddProduct(Product product);
        IReadOnlyCollection<Product> GetProducts();
    }
}
