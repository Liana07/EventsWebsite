using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventsWebsite.Models;
using System.Data.Entity;
using System.Net;


namespace EventsWebsite.Controllers
{
    public class SiteController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Events
        public ActionResult Index()
        {
            var topic = db.Topics.ToList();
            return View(topic);
        }

        // GET: /Site/Browse
        public ActionResult Browse(int id)
        {

           var  topicModel = db.Topics.Include(a => a.Events).Single(g => g.TopicId == id);
            return View(topicModel);
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Events events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }


        public ActionResult WebSlice()
        {
            DateTime compareDate = DateTime.Now.AddMonths(10);
            var model = from events in db.Events
                        where events.Date < compareDate
                        orderby events.Date descending
                        select events;
             return PartialView("WebSlice", model.Take(3));
        }

        }
    }
