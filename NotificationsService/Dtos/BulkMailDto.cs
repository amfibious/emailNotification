using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationsService.Dtos
{
    public class BulkMailDto
    {
        public MailAddress Sender { get; set; }
        public IList<MailAddress> Receivers { get; set; }
        public string Subject { get; set; }
        public MailBodyDto Body { get; set; }
    }
}
