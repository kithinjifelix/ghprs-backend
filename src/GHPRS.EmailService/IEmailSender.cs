using Azure.Communication.Email.Models;

namespace GHPRS.EmailService;

public interface IEmailSender
{
    Task<SendEmailResult> SendEmailAzure(Message message); 
}