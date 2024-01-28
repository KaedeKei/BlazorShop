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
		private readonly SmtpClient _client = new();

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
			
			await EnsureConnectedAndAuthed();
			await _client.SendAsync(emailMessage);
			await _client.DisconnectAsync(true);
		}

		private async Task EnsureConnectedAndAuthed()
		{
			if (!_client.IsConnected)
			{
				await _client.ConnectAsync(_host, _port, false);
			}
			if (!_client.IsAuthenticated)
			{
				await _client.AuthenticateAsync(_userName, _password);
			}
		}

		public async ValueTask DisposeAsync()
		{
			await _client.DisconnectAsync(true);
			_client.Dispose();
		}
	}
}
