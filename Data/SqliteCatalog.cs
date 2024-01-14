using BlazorShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Data
{
    public class SqliteCatalog : ICatalog
    {
        private readonly AppDbContext _dbContext;


        public void AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }

        public IReadOnlyCollection<Product> GetProducts()
        {
            return _dbContext.Products.ToList();
        }

        public SqliteCatalog(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void GetById(int Id) //пока некуда применять, но пусть тут побудет
       => _dbContext.Products.First(it => it.Id == Id);

        public void Update(Product product) //пока некуда применять, но пусть тут побудет
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

    }
}
