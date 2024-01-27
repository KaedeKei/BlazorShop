using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace BlazorShop.Data
{
	public class SmptConfiguration : ISmtpConfiguration
	{
		private IConfiguration _configuration;
		[Required] private string Host;
		[EmailAddress] private string UserName;
		[Required] private string Password;
		[Range(1, ushort.MaxValue)] private int Port;

		public SmptConfiguration()
		{
			_configuration = new ConfigurationBuilder().AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();
			Host = _configuration["Host"];
			UserName = _configuration["UserName"];
			Password = _configuration["Password"];
			Port = Convert.ToInt32(_configuration["port"]);
		}		

		public string GetHost()
		{
			return Host;
		}

		public string GetUserName()
		{
			return UserName;
		}

		public string GetPassword()
		{
			return Password;
		}

		public int GetPort()
		{
			return Port;
		}
	}
}
