using MimeKit;
using MailKit.Net.Smtp;
namespace BlazorShop.Services
{
    public class EmailServiceMailKit
    {
        public void SendEmail(string mail_subject, string message)
        {
            using var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Сообщение с сайта BlazorShop", "my@mail.ru"));
            emailMessage.To.Add(new MailboxAddress("", "my@mail.ru"));
            emailMessage.Subject = mail_subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.mail.ru", 25, false);
                client.Authenticate("login@yandex.ru", "password");
                client.Send(emailMessage);
                client.Disconnect(true);
            }
        }
    }
}