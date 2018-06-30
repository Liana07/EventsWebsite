using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventsWebsite.Models;


namespace EventsWebsite.Controllers
{
    public class RsvpController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        // HTTP: /Rsvp/Register/1
        public ActionResult Register(int id)
        {
            //call the function 
            RegisterForEvent(id);
            //redirect to action with parameters, the action, the controler, the id 
            return RedirectToAction("Details", "Site", new { id = id });
        }

        //
        // AJAX: /Events/RegisterAjax/1
        [Authorize, HttpPost]
        public ActionResult RegisterAjax(int id)
        {
            RegisterForEvent(id);
            return Content("Thanks - we'll see you there!");
        }

        private void RegisterForEvent(int id)
        {
            Events events = db.Events.Find(id);

            if (!events.IsUserRegistered(User.Identity.Name))
            {
                Rsvp rsvp = new Rsvp();
                rsvp.AttendeeName = User.Identity.Name;

                events.Rsvps.Add(rsvp);
                db.SaveChanges();
            }
        }

        //
        // AJAX: /Rsvp/CancelAjax/1

        [Authorize, HttpPost]
        public ActionResult CancelAjax(int id)
        {
            Events events = db.Events.Find(id);

            Rsvp rsvp = events.Rsvps.SingleOrDefault(r => this.User.Identity.Name == r.AttendeeName);
            if (rsvp != null)
            {
                db.Rsvps.Remove(rsvp);
                db.SaveChanges();
            }

            return Content("Sorry you can't make it!");
        }
    }
}
