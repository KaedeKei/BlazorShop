using BlazorShop.Models;

namespace BlazorShop.Data.Irrelevant

{
    public class InFileCatalogNotAsync : ICatalogNotAsync
    {
        private readonly string fileName;

        public InFileCatalogNotAsync(string fileName)
        {
            this.fileName = fileName;
        }

        public IReadOnlyCollection<Product> GetProducts()
        {
            var products = new List<Product>();

            using (var reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var parts = line.Split(';');

                    var product = new Product
                    {
                        Id = int.Parse(parts[0]),
                        Name = parts[1],
                        Price = decimal.Parse(parts[2])
                    };

                    products.Add(product);
                }
            }

            return products;
        }

        public void AddProduct(Product product)
        {
            var lastId = 0;

            if (File.Exists(fileName))
            {
                using var reader = new StreamReader(fileName);

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var parts = line.Split(';');

                    lastId = int.Parse(parts[0]);
                }
            }

            using (var writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine($"{lastId + 1};{product.Name};{product.Price}");
            }
        }
    }
}
