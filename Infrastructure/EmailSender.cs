using System;
using System.Net.Mail;

namespace Infrastructure
{
    public class EmailSender
    {
        public static void Send(string To, string Subject, string MessageBody)
        {
            var message = new MailMessage("WebAppSecurityClass@gmail.com", To)
            {
                Subject = Subject,
                IsBodyHtml = true,
                Body = MessageBody,
            };
            var client = new SmtpClient() { EnableSsl = true };
            try
            {
                client.Send(message);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void Send(MailMessage Message)
        {
            var client = new SmtpClient() { EnableSsl = true };
            try
            {
                client.Send(Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
