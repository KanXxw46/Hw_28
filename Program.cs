using System;
using System.Net;
using System.Net.Mail;

namespace Hw28._20
{
    class Program
    {
        static void Main(string[] args)
        {
            MailAddress fromMailAddress = new MailAddress("skidan.oleg@gmail.com", "Учитель");
            MailAddress toAddress = new MailAddress("1kan_andreikkk@mailinator.com", "Ученик");

            using (MailMessage mailMessage = new MailMessage(fromMailAddress, toAddress))
            using (SmtpClient smtpClient = new SmtpClient())
            {
                mailMessage.Subject = "My Subject";
                mailMessage.Body = "Text in the body";

                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(fromMailAddress.Address, "pass");

                smtpClient.Send(mailMessage);
            }
        }
    }
}
