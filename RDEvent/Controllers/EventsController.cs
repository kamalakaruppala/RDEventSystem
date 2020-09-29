using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RDEvent.Models;
namespace RDEvent.Controllers
{
    public class EventsController : Controller
    {
        // GET: Events
        public ActionResult Index()

        {
            Database1Entities selectevent = new Database1Entities();
            var cl = from m in selectevent.Addevents
                     orderby m.EventID
                     select m;
            return View(cl);
        }
        public ActionResult AdminEvents()
        {
            Database1Entities selectevent = new Database1Entities();
            var cl = from m in selectevent.Addevents
                     orderby m.EventID
                     select m;
            return View(cl);
        }
        public ActionResult AddEvents()
        {
            return View();
}
        [HttpPost] 
       public ActionResult AddEvents(Addevent modem)
        {
            Database1Entities s = new Database1Entities();

            if (ModelState.IsValid)
            {
                s.Addevents.Add(modem);
                s.SaveChanges();

                
                return View();

            }
            else
            {
                return View();
            }
        }
        
        public ActionResult EditEvent()
        {
            return View();
        }
        [HttpPost]

        public String EditEvent(int EventID, string EventName, String Region, String Description, String Date, String City, String TypeofEvent, String NumberOfOfficialsNeeded)
        {
            Database1Entities edit = new Database1Entities();
            Addevent p = edit.Addevents.Find(EventID);
            p.EventName = EventName;
            p.Region = Region;
            p.Description = Description;
            p.Date = Date;
            p.City = City;
            p.TypeofEvent = TypeofEvent;
            p.NumberOfOfficialsNeeded = NumberOfOfficialsNeeded;
            edit.SaveChanges();
            return "Done";
        }
    }
}