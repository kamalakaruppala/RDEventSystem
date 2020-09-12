using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult EditEvent()
        {
            return View();
        }
    }
}