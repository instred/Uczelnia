using System;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace Z1
{
    class SmtpFacade
    {

        private string password;
        public SmtpFacade(string passwrd) { password = passwrd; }

        public void Send(string From, string To, string Subject, string Body, Stream Attachment, string AttachmentMimeType)
        {

            SmtpClient client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(From, password),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            MailMessage message = new MailMessage(From, To, Subject, Body);

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wyjątek przy wysyłaniu: " + ex.ToString());
                Console.ReadLine();
            }
        }
    }
}