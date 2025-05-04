using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;
using System;

public class EmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        // This just logs the email to the console.
        Console.WriteLine($"[EmailSender] To: {email}, Subject: {subject}");
        return Task.CompletedTask;
    }
}
