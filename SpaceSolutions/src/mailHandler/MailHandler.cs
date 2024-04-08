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
    /// <summary>
    /// Class that handles creating and sending emails
    /// </summary>
    internal class MailHandler
    {
        /// <summary>
        /// Method to send an email
        /// </summary>
        /// <param name="senderEmail"> the email of the sender </param>
        /// <param name="senderPassword"> the passowrd for the email of the sender </param>
        /// <param name="receiverEmail"> the email of the receiver </param>
        /// <param name="body"> the body of the message </param>
        /// <param name="attachmentPath"> path to csv to attach to mail </param>
        public void sendResultEmail(string senderEmail, string senderPassword, string receiverEmail, string body, string attachmentPath)
        {
            MailMessage mailMessage = createMessage(senderEmail, receiverEmail, body, attachmentPath);
            SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com")
            {
                Credentials = new NetworkCredential(senderEmail, senderPassword),
                EnableSsl = true,
            };
            smtpClient.Send(mailMessage);
        }
        /// <summary>
        /// Helper method to create the email to be sent
        /// </summary>
        /// <param name="senderEmail"> the email of the sender </param>
        /// <param name="receiverEmail"> the email of the receiver </param>
        /// <param name="body"> the body of the message </param>
        /// <param name="attachmentPath"> path to csv to attach to mail </param>
        /// <returns> the MailMessage object contaning the email </returns>
        private MailMessage createMessage(string senderEmail, string receiverEmail, string body, string attachmentPath)
        {
            MailMessage mailMessage = new MailMessage()
            {
                From = new MailAddress(senderEmail),
                Subject = "Best launch date",
                Body = body,
            };
            mailMessage.To.Add(receiverEmail);
            mailMessage.Attachments.Add(new Attachment(attachmentPath, MediaTypeNames.Text.Csv));
            return mailMessage;
        }
    }
}
