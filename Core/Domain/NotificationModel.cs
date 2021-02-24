using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoolExplorer.Model
{
    public class NotificationModel
    {
        public string Subject { get; set; }
        public List<string> RecipientEmails { get; set; }
        public int NotificationChannel { get; set; }
        public char NotificationType { get; set; }
    }
}
