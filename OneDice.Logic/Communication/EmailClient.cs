using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace OneDice.Logic
{
    public class EmailClient 
    {
        public static bool SendGridDoNotReply(string to, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage("donotreply@onedice.com", to);
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = "smtp.sendgrid.net";
                client.Timeout = 10000;
                client.Credentials = new System.Net.NetworkCredential("onedice", "k9ng9rru");

                mail.Subject = subject;
                mail.Body = body;
                client.Send(mail);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool SendGridSupport(string to, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage("support@onedice.com", to);
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = "smtp.sendgrid.net";
                client.Timeout = 10000;
                client.Credentials = new System.Net.NetworkCredential("onedice", "k9ng9rru");

                mail.Subject = subject;
                mail.Body = body;
                client.Send(mail);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool GoogleDoNotReply(string to, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage("donotreply@onedice.com", to);
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("onedice1@gmail.com", "kangarru");

                mail.Subject = subject;
                mail.Body = body;
                mail.BodyEncoding = UTF8Encoding.UTF8;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                client.Send(mail);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool GoogleSupport(string to, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage("support@onedice.com", to);
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("onedice1@gmail.com", "kangarru");

                mail.Subject = subject;
                mail.Body = body;
                mail.BodyEncoding = UTF8Encoding.UTF8;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
