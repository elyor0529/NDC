using System;
using System.IO;
using System.Net.Mail;
using SendGrid;

namespace NDC.Common.Utils
{
    public static class SendGridTool
    {
        /// <summary>
        ///     SendGrid send sync email
        ///     https://sendgrid.com/docs/Integrate/Code_Examples/csharp.html
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="attachments"></param>
        /// <param name="sendGridKey"></param>
        /// <param name="fromEmail"></param>
        /// <returns></returns>
        public static void Send(string sendGridKey, string fromEmail, string toEmail, string subject, string body, params string[] attachments)
        {
            if (string.IsNullOrWhiteSpace(fromEmail))
                throw new ArgumentNullException(nameof(fromEmail));

            if (string.IsNullOrWhiteSpace(toEmail))
                throw new ArgumentNullException(nameof(toEmail));

            if (string.IsNullOrWhiteSpace(subject))
                throw new ArgumentNullException(nameof(subject));

            if (string.IsNullOrWhiteSpace(body))
                throw new ArgumentNullException(nameof(body));

            var message = new SendGridMessage();
            message.AddTo(toEmail);
            message.From = new MailAddress(fromEmail);
            message.Subject = subject;

            //by default sended text format
            message.Text = body;

            //if set for this property , sended HTML format
            message.Html = body;

            // by default this enabled,after them faster sended no tracked at SendGrid server
            message.DisableClickTracking();

            //check attachments
            if (attachments != null)
                foreach (var attachment in attachments)
                    message.AddAttachment(attachment);

            // Create a Web transport for sending email. 
            var transportWeb = new Web(sendGridKey);

            // Send the email.
            transportWeb.DeliverAsync(message).GetAwaiter().GetResult();

            //after delivered we to need delete recently files
            if (attachments != null)
                foreach (var attachment in attachments)
                    File.Delete(attachment);
        }
    }
}