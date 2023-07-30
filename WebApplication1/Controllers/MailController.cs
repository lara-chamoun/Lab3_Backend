using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmailController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly MailService _mailService;

    public EmailController(IConfiguration configuration, MailService mailService)
    {
        _configuration = configuration;
        _mailService = mailService;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendEmail(
        [FromForm] string recipient,
        [FromForm] string subject,
        [FromForm] string body
    )
    {
        // Here you can validate the email parameters if needed before sending the email.
        // ...

        // Send the email using the MailService
        await _mailService.SendEmailAsync(recipient, subject, body);

        return Ok("Email sent successfully!");
    }
}