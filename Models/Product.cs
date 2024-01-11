using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Models
{
	public class Product
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Название должно быть заполнено")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Цена долдна быть заполнена")]
		[Range(0, 1000000, ErrorMessage = "Цена должна быть от 0 до 1000000")]
		public decimal Price { get; set; }

		public Product(int id, string name, decimal price)
		{
		Id = id;
		Name = name;
		Price = price;
		}

		public Product(string name, decimal price)
		{
			Name = name;
			Price = price;
		}

		public Product()
		{
		
		}

		public override string ToString()
		{
			return this.Id + ". " + this.Name + " - " + this.Price.ToString("C");
		}
	}
}
