using MailKit.Net.Smtp;
using MimeKit;

namespace GHPRS.EmailService;

public class EmailSender : IEmailSender
{
    private readonly EmailConfiguration _emailConfiguration;

    public EmailSender(EmailConfiguration emailConfiguration)
    {
        _emailConfiguration = emailConfiguration;
    }
    public void SendEmail(Message message)
    {
        var emailMessage = CreateEmailMessage(message);
        Send(emailMessage);
    }

    public async Task SendEmailAsync(Message message)
    {
        var emailMessage = CreateEmailMessage(message);
        await SendAsync(emailMessage);
    }

    private MimeMessage CreateEmailMessage(Message message)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress(_emailConfiguration.From_Name, _emailConfiguration.From));
        emailMessage.To.AddRange(message.To);
        emailMessage.Subject = message.Subject;

        var bodyBuilder = new BodyBuilder
            { HtmlBody = string.Format("<h2 style='color:red;'>{0}</h2>", message.Content) };
        if (message.Attachments.Any())
        {
            byte[] fileBytes;
            foreach (var attachment in message.Attachments)   
            {
                using (var ms = new MemoryStream())
                {
                    attachment.CopyTo(ms);
                    fileBytes = ms.ToArray();
                }

                bodyBuilder.Attachments.Add(attachment.FileName, fileBytes, ContentType.Parse(attachment.ContentType));
            }
        }

        emailMessage.Body = bodyBuilder.ToMessageBody();
        return emailMessage;
    }
    
    private void Send(MimeMessage emailMessage)
    {
        using (var client = new SmtpClient())
        {
            try
            {
                client.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_emailConfiguration.UserName, _emailConfiguration.Password);

                client.Send(emailMessage);
            }
            catch (Exception e)
            {
                // Inform people email was not sent
                throw e;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
    
    private async Task SendAsync(MimeMessage emailMessage)
    {
        using (var client = new SmtpClient())
        {
            try
            {
                client.ServerCertificateValidationCallback = (s, c, ch, e) => true;

                await client.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.Port,
                    MailKit.Security.SecureSocketOptions.Auto);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync(_emailConfiguration.UserName, _emailConfiguration.Password);

                await client.SendAsync(emailMessage);
            }
            catch (Exception e)
            {
                // Inform people email was not sent
                throw e;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}