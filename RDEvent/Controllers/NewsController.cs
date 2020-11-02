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
            Database1Entities3 selectnews = new Database1Entities3();
            var bl = from b in selectnews.News
                     orderby b.NewsID
                     select b;
            return View(bl);
        }
        public ActionResult UserNews()
        {
            Database1Entities3 selectnews = new Database1Entities3();
            var bl = from b in selectnews.News
                     orderby b.NewsID
                     select b;
            return View(bl);
        }


        public ActionResult AdminNews()
        {
            Database1Entities3 selectnews = new Database1Entities3();
            var bl = from b in selectnews.News
                     orderby b.NewsID
                     select b;
            return View(bl);
            
        }
        public ActionResult AddNews()
        {


            return View();

        }
        [HttpPost]
        public ActionResult AddNews(News modem)
        {
            Database1Entities3 k = new Database1Entities3();

            if (ModelState.IsValid)
            {
                k.News.Add(modem);
                k.SaveChanges();


                return RedirectToAction("AdminNews", "News");
            }
            else
            {
                return View();
            }
        }
        public ActionResult delete(string NewsTitle)
        {

            Database1Entities3 db1 = new Database1Entities3();
            News del = db1.News.FirstOrDefault(X => X.NewsTitle == NewsTitle);

            db1.News.Remove(del);

            db1.SaveChanges();

            return View();

        }

    }
}
       
    
