using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;



namespace EventsWebsite.Models
{
    public class Events
    {
        [Key]
        public int EventId { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [StringLength(50, ErrorMessage = "Title may not be longer than 50 characters")]
        public string Title { get; set; }
        // one to many relationship- one topic has many events 
        [Display(Name = "Topic")]
        public int TopicId { get; set; } 

        [Required(ErrorMessage = "Description is required")]
        [StringLength(200, ErrorMessage = "Description may not be longer than 200 characters")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Event Date is required")]
        [Display(Name = "Event Date")]

        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Location is required")]
        [StringLength(50, ErrorMessage = "Location may not be longer than 50 characters")]

        public string Location { get; set; }
        public string ImageEvent { get; set; }
    
        public virtual Topic Topic { get; set; }
       
        //one to many relationship - one event has many rsvps
        public virtual ICollection<Rsvp> Rsvps { get; set; }

        public bool IsUserRegistered(string userName)
        {
            //Determines whether a sequence contains any elements.
            return Rsvps.Any(r => r.AttendeeName == userName);
        }
    }
}