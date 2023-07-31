using Entities;
using System.Net;
using System.Net.Mail;

namespace CoreWeb.Utils
{
    public class MailHelper
    {
        public static bool SendMail(Contact contact)
        {
			try
			{
                SmtpClient client = new SmtpClient("mail.coreweb.com", 587);
                client.Credentials = new NetworkCredential($"{contact.Name}", "email şifre");
                //client.EnableSsl = true; // Eğer mailde ssl kullanılıyorsa kullanılır.
                
                MailMessage message = new MailMessage();
                message.From = new MailAddress("info@coreweb.com");
                message.To.Add($"{contact.Email}");
                message.Subject = "CoreWeb'den Mesajınız Var!";
                message.Body = $"<p> Mesaj Bilgileri; <hr />" +
                    $" İsim : {contact.Name} <hr />" +
                    $" Telefon :  {contact.Phone} <hr />" +
                    $" Telefon :  {contact.Phone} <hr />" +
                    $" Tarih :  {contact.CreateDate} </p>";
                message.IsBodyHtml = true;

                client.Send(message);

                return true;
			}
			catch (Exception)
			{
                return false;
			}
        }
    }
}
