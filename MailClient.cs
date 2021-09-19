using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using System.IO;
using WebRentManager.Models;
using MimeKit.Text;

namespace WebRentManager
{
    public class MailClient
    {
        public void Smtp(MimeMessage message)
        {
            message.From.Add(new MailboxAddress(""));  // TODO Dodać adres z którego będziemy wysyłaś
            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("", 587, false);  // TODO Dodać nazwę serwera wychodzącego

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("", "");  // Login i hasło do poczty wychodzącej

                client.Send(message);
                client.Disconnect(true);
            }
        }
        public void SendMailAttachment(string toAdress,string toName, string ccAdress,string ccName, MailMessage customMessage, List<Guid> fileIds)
        {
            var message = new MimeMessage();
            message.To.Add(new MailboxAddress(toName, toAdress));
            if (ccAdress!="")
            {
                message.Cc.Add(new MailboxAddress(ccName, ccAdress));
            }
            message.Subject = customMessage.Subject;

        }
        public void SendMail(string toAdress, string toName, string ccAdress, string ccName, MailMessage customMessage)
        {
            var message = new MimeMessage();
            message.To.Add(new MailboxAddress(toName, toAdress));
            if (ccAdress != "")
            {
                message.Cc.Add(new MailboxAddress(ccName, ccAdress));
            }
            message.Subject = customMessage.Subject;
            message.Body = new TextPart(TextFormat.RichText)
            {
                Text=customMessage.Content
            };

        }
        public void SendTestMail()
        {
            var message = new MimeMessage();
            message.To.Add(new MailboxAddress("", ""));
            message.From.Add(new MailboxAddress("", ""));
            message.Subject = "Testowa wiadomość";

            message.Body = new TextPart("plain")
            {
                Text = @"Testowa wiadomość z serwera"
            };

        }
    }
}
