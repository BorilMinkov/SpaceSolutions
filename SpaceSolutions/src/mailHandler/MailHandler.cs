using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSolutions.src.mailHandler
{
    internal class MailHandler
    {
        public void sendResultEmail(string senderEmail, string senderPassword, string receiverEmail, string body, string attachmentPath)
        {
            MailMessage mailMessage = createMessage(senderEmail, receiverEmail, body, attachmentPath);
            SmtpClient smtpClient = new SmtpClient("smtp.outlook.com")
            {
                Credentials = new NetworkCredential(senderEmail, senderPassword),
                EnableSsl = true,
            };
            smtpClient.Send(mailMessage);
        }

        private MailMessage createMessage(string senderEmail, string receiverEmail, string body, string attachmentPath)
        {
            MailMessage mailMessage = new MailMessage()
            {
                From = new MailAddress(senderEmail),
                Subject = "best launch date" ,
                Body = body,
            };
            mailMessage.To.Add(receiverEmail);
            mailMessage.Attachments.Add(new Attachment(attachmentPath, MediaTypeNames.Text.Csv));
            return mailMessage;
        }
    }
}
