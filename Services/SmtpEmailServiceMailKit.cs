using MailKit.Net.Smtp;
using MimeKit;

namespace BlazorShop.Services
{
	public class SmtpEmailServiceMailKit
	{
		private string _host;
		private string _userName;
		private string _password;
		private int _port;

		public SmtpEmailServiceMailKit(string host, string userName, string password,int port)
		{
			_host = host;
			_userName = userName;
			_password = password;
			_port = port;
		}

		public async Task SendEmailAsync(string mailSubject, string message)
		{
			using var emailMessage = new MimeMessage();

			emailMessage.From.Add(new MailboxAddress("Сообщение с сайта BlazorShop", _userName));
			emailMessage.To.Add(new MailboxAddress("", _userName));
			emailMessage.Subject = mailSubject;
			emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
			{
				Text = message
			};

			using (var client = new SmtpClient())
			{
				await client.ConnectAsync(_host, _port, false);
				await client.AuthenticateAsync(_userName, _password);
				await client.SendAsync(emailMessage);
				await client.DisconnectAsync(true);
			}
		}

	}
}
