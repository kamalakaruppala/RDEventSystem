using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RDEvent.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Verification()
        {
            return View();
        }
        public ActionResult Verified()
        {
            return View();
        }
    }
}