using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace NotificationsService.Dtos
{
    public class MailDto
    {
        public string Subject { get; set; }
        [Required]
        public MailAddress Sender { get; set; }
        [Required]
        public MailAddress Receiver { get; set; }
        [Required]
        public MailBodyDto Body { get; set; }
        public IList<string> Cc { get; set; }
        public IList<string> Bcc { get; set; }
    }
}
