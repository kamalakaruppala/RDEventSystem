using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RDEvent.Models;
namespace RDEvent.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            Database1Entities selectnews = new Database1Entities();
            var bl = from b in selectnews.News
                     orderby b.NewsID
                     select b;
            return View(bl);
        }
        public ActionResult AdminNews()
        {
            return View();
        }
    }
       
    }
