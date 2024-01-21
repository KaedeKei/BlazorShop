namespace BlazorShop.Data
{
	public interface ISmtpConfiguration
	{
		public string GetHost();
		public string GetUserName();
		public string GetPassword();		
		public int GetPort();
	}
}
