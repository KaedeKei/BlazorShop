using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
namespace BlazorShop.Services.Irrelevant
{
    public class SmtpEmailServiceMailKit
    {
        public async Task SendEmailAsync(string mailSubject, string message)
        {
            using var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Сообщение с сайта BlazorShop", "my@mail.ru"));
            emailMessage.To.Add(new MailboxAddress("", "my@mail.ru"));
            emailMessage.Subject = mailSubject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.mail.ru", 25, false);
                await client.AuthenticateAsync("my@mail.ru", "passwird");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}