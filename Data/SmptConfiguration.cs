using System.Reflection;

namespace BlazorShop.Data
{
	public class SmptConfiguration : ISmtpConfiguration
	{
		private IConfiguration _configuration = new ConfigurationBuilder().AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();

		public string GetHost()
		{
			return _configuration["Host"];
		}

		public string GetUserName()
		{
			return _configuration["UserName"];
		}

		public string GetPassword()
		{
			return _configuration["Password"];
		}

		public int GetPort()
		{
			var port = _configuration["port"];

			return Convert.ToInt32(port);
		}
	}
}
