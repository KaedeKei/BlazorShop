using BlazorShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Data
{
    public class SqliteCatalogAsync : ICatalogAsync
    {
        private readonly AppDbContext _dbContext;

        public async Task AddProduct(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task <IReadOnlyCollection<Product>> GetProducts()
        {
			var list = await _dbContext.Products.ToListAsync();
			return list.AsReadOnly();
		}

        public SqliteCatalogAsync(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

		public async Task GetById(int Id) //пока некуда применять, но пусть тут побудет
       => _dbContext.Products.FirstAsync(it => it.Id == Id);

        public async Task Update(Product product) //пока некуда применять, но пусть тут побудет
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
	}
}
