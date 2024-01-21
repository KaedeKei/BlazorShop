using BlazorShop.Data;

namespace BlazorShop.Services
{
    public class SmtpEmailSenderMailKit : IEmailSender
    {
		public readonly ISmtpConfiguration _configuration = new SmptConfiguration();

		public async Task SendMailAsync(string usersEmail, string mailSubject, string mailBody)
        {
			SmtpEmailServiceMailKit emailService = new SmtpEmailServiceMailKit(_configuration.GetHost(), _configuration.GetUserName(), _configuration.GetPassword(), _configuration.GetPort());

            string myMessage = "E-mail отправителя: " + usersEmail + "<br> Текст сообщения: " + mailBody;

            await emailService.SendEmailAsync(mailSubject, myMessage);
		}
    }
}
