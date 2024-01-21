namespace BlazorShop.Services
{
    public interface IEmailSender
    {
        public Task SendMailAsync(string usersEmail, string mailSubject, string mailBody);
    }
}
