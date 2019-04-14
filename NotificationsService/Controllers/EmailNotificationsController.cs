using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationsService.Dtos;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;

namespace NotificationsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailNotificationsController : ControllerBase
    {
        // POST: api/EmailNotifications
        [HttpPost("[action]")]
        public async Task SendMail([FromBody] MailDto email)
        {
            var message = new MimeMessage();

            message.Sender = new MailboxAddress(email.Sender.Name, email.Sender.Address);
            message.From.Add(new MailboxAddress(email.Receiver.Name, email.Receiver.Address));
            message.Subject = email.Subject;
            message.Priority = MessagePriority.Urgent;
            message.Body = new TextPart(email.Body.ContentType)
            {
                Text = email.Body.Content
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, false);
                await client.AuthenticateAsync("<email>", "<password>");
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
