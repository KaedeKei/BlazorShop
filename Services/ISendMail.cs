namespace BlazorShop.Services
{
    public interface ISendMail
    {
        public void SendMail(string user_email, string mail_subject, string mail_body);
    }
}
