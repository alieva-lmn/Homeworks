using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailClient
{
    public class EmailMessage
    {
        public string Subject { get; set; }
        public string From { get; set; }
        public string Date { get; set; }
        public string Body { get; set; }
    }
}
