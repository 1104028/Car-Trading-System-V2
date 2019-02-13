using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace CarTradingSystem
{
   public class MailClient
    {
        public string from { get; set; }
        public string to { get; set; }
        public string clientAddr { get; set; }
        public int clientPort { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string hostID { get; set; }
        public string hostPass { get; set; }
        public Attachment att { get; set; }


        public void SendMail()
        {
            MailMessage mail = new MailMessage(from, to);
            SmtpClient SmtpServer = new SmtpClient(clientAddr);
            SmtpServer.Port = clientPort;
            mail.Subject = Subject;
            mail.Body = Body;
         

            // mail.Attachments[mail.Attachments.Count - 1].ContentId = "gcs_logo.jpg";
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpServer.Credentials = new System.Net.NetworkCredential(hostID, hostPass);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }
        public void SendMailWithAttach()
        {
            MailMessage mail = new MailMessage(from, to);
            SmtpClient SmtpServer = new SmtpClient(clientAddr);
            SmtpServer.Port = clientPort;
            mail.Subject = Subject;
            mail.Body = Body;
            mail.Attachments.Add(att);

            // mail.Attachments[mail.Attachments.Count - 1].ContentId = "gcs_logo.jpg";
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpServer.Credentials = new System.Net.NetworkCredential(hostID, hostPass);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }
    }

}