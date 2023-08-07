using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using MailKit.Net.Imap;
using MailKit;
using System.Collections.ObjectModel;
using MimeKit;
using Microsoft.Win32;
using MailKit.Security;
using MailKit.Net.Smtp;

namespace MailClient
{
    public static class MailService
    {
        public static void SendEmail(string receiver, string subject, BodyBuilder body)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Laman Aliyeva", "alievalmn@gmail.com"));
            message.To.Add(new MailboxAddress("Recipient Name", receiver));
            message.Subject = subject;
            message.Body = body.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                client.Authenticate("alievalmn@gmail.com", "fgkuxvtwixqdipar");
                client.Send(message);
                client.Disconnect(true);
            }
        }

        public static void AttachFile(BodyBuilder _builder)
        {
            string filePath = string.Empty;

            var openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                filePath = openFileDialog.FileName;
            }

            var attachment = new MimePart("application", "octet-stream")
            {
                Content = new MimeContent(System.IO.File.OpenRead(filePath)),
                ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                ContentTransferEncoding = ContentEncoding.Base64,
                FileName = System.IO.Path.GetFileName(filePath)
            };

            _builder.Attachments.Add(attachment);
        }
        public static ObservableCollection<EmailMessage> GetAllMail()
        {
            ObservableCollection<EmailMessage> messages = new();

            string host = "imap.gmail.com";
            int port = 993;
            bool useSsl = true;
            string username = "alievalmn@gmail.com";
            string password = "fgkuxvtwixqdipar";

            using (var client = new ImapClient())
            {
                client.Connect(host, port, useSsl);

                client.Authenticate(username, password);

                client.Inbox.Open(FolderAccess.ReadOnly);

                int count = client.Inbox.Count;
                int startIndex = count > 10 ? count - 10 : 0;

                for (int i = startIndex; i < count; i++)
                {
                    var message = client.Inbox.GetMessage(i);

                    messages.Add(new EmailMessage
                    {
                        Subject = message.Subject,
                        From = message.From.ToString(),
                        Date = message.Date.LocalDateTime.ToString(),
                        Body = message.TextBody
                    });
                }

                client.Disconnect(true);
                return messages;
            }
        }
    }

    
}
