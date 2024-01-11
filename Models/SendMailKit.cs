﻿using SocialApp.Services;

namespace BlazorShop.Models
{
	public class SendMailKit : ISendMail
	{
		public void SendMail(string user_email, string mail_subject, string mail_body) 
		{
			EmailService emailService = new EmailService();

			string myMessage = "E-mail отправителя: " + user_email + "<br> Текст сообщения: " + mail_body;

			emailService.SendEmail(mail_subject, myMessage);
		}
	}
}