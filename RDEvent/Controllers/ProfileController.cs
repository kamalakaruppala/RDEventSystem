using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RDEvent.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Experience()
        {
            return View();
        }
        public ActionResult NonSkating()
        {
            return View();
        }
        public ActionResult Availability()
        {
            return View();
        }
    }
}