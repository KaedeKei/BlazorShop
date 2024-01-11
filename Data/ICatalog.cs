using BlazorShop.Data;
using BlazorShop.Models;
using System.Data.SqlClient;

namespace BlazorShop.Data
{
    public interface ICatalog
    {
        IReadOnlyCollection<Product> GetProducts();
        void AddProduct(Product product);
    }
}

class InMssqlCatalog : ICatalog
{
    private readonly string connectionString;

    public InMssqlCatalog(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public IReadOnlyCollection<Product> GetProducts()
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Products";

        var reader = command.ExecuteReader();

        var products = new List<Product>();

        while (reader.Read())
        {
            var product = new Product
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Price = reader.GetDecimal(2)
            };

            products.Add(product);
        }

        return products;

    }


    public void AddProduct(Product product)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Products (Name, Price) VALUES (@name, @price)";
        command.Parameters.AddWithValue("@name", product.Name);
        command.Parameters.AddWithValue("@price", product.Price);

        command.ExecuteNonQuery();
    }
}