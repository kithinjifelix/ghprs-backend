using Azure.Communication.Email.Models;

namespace GHPRS.EmailService;

// public class EmailAddress
// {
//     public string Address { get; set; }
//     public string DisplayName { get; set; }
// }
public class Message
{
    public List<EmailAddress> To { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }

    public Message(IEnumerable<EmailAddress> to, string subject, string content)
    {
        To = new List<EmailAddress>();
        
        To.AddRange(to.Select(x => new EmailAddress(x.Email, x.DisplayName)));
        Subject = subject;
        Content = content;
    }
}