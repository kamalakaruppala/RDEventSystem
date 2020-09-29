using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RDEvent.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    [Authorize]
        public ActionResult Users()
        {
            return View();
        }
        public ActionResult Admin()
        {
            return View();
        }
    }
}