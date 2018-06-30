using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsWebsite.Models
{
    public class Rsvp
    {
        public int RsvpID { get; set; }
        public int EventId { get; set; }
        public string AttendeeName { get; set; }

        public virtual Events Events { get; set; }
    }
}