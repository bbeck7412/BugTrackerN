using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker.Models
{
    public class TicketDetailViewModel
    {
        public Ticket Ticket { get; set; }
        public ApplicationUser ProjectManager { get; set; }
        public TicketAttachment TicketAttachment { get; set; }
    }
}