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
            return View();
        }
        public ActionResult AdminEvents()
        {
            return View();
        }
        public ActionResult AddEvents()
        {
            return View();
}
       
        public ActionResult Index(Addevent modem)
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
    }
}