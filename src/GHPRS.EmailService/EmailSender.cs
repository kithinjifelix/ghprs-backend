using Azure.Communication.Email;
using Azure.Communication.Email.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
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
        SendEmailAzure(message);
    }

    public async Task SendEmailAsync(Message message)
    {
        await SendEmailAzure(message);
    }

    public async Task<SendEmailResult> SendEmailAzure(Message message)
    {
        try
        {
            EmailClient _emailClient = new EmailClient(_emailConfiguration.COMMUNICATION_SERVICES_CONNECTION_STRING);
            EmailContent emailContent = new EmailContent(message.Subject);
            emailContent.Html = message.Content;
            List<EmailAddress> emailAddresses = new List<EmailAddress>();
            emailAddresses.AddRange(message.To);
            
            EmailRecipients emailRecipients = new EmailRecipients(emailAddresses);
            EmailMessage emailMessage = new EmailMessage("DoNotReply@932b7c05-cc32-47bb-9ec7-0a3b70a7df9e.azurecomm.net", emailContent, emailRecipients);
            SendEmailResult emailResult = await _emailClient.SendAsync(emailMessage,CancellationToken.None);
            return emailResult;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}