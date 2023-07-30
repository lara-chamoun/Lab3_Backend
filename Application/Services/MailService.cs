
using Microsoft.Extensions.Configuration;
using MimeKit;
using MailKit.Net.Smtp;

public class MailService
{
    private readonly string _gmailAddress;
    private readonly string _gmailPassword;

    public MailService(IConfiguration configuration)
    {
        _gmailAddress = configuration["Gmail:EmailAddress"];
        _gmailPassword = configuration["Gmail:Password"];
    }

    public async Task SendEmailAsync(string recipient, string subject, string body)
    {
        await SendEmailViaGmailApi(recipient, subject, body);
    }

    private async Task SendEmailViaGmailApi(string recipient, string subject, string body)
    {
        var message = CreateEmail(recipient, _gmailAddress, subject, body);

        using (var client = new SmtpClient())
        {
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate(_gmailAddress, _gmailPassword);
            await client.SendAsync(message);
            client.Disconnect(true);
        }
    }

    private MimeMessage CreateEmail(string to, string from, string subject, string body)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("", from));
        message.To.Add(new MailboxAddress("", to));
        message.Subject = subject;

        var bodyBuilder = new BodyBuilder();
        bodyBuilder.HtmlBody = body;

        message.Body = bodyBuilder.ToMessageBody();

        return message;
    }
}