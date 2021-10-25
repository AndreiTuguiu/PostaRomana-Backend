using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PostaRomanaBackend.Application.Helpers
{
    public class EmailSender
    {
        private static string email = "posta.romana33@gmail.com";
        private static string password = "Posta.romana33!";
        private static string host = "smtp.gmail.com";
        private static int port = 587;

        public static void sendEmail(string to, string token)
        {
            SmtpClient smtpClient = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(email, password),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(email),
                Subject = "Token for your registration",
                Body = $"<h1>Hello, this is the token: {token}</h1>",
                IsBodyHtml = true,
            };
            mailMessage.To.Add(to);

            smtpClient.Send(mailMessage);
        }
    }
}
