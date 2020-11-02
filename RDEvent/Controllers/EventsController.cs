using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RDEvent.Models;
namespace RDEvent.Controllers
{
   
    public class EventsController : Controller
    {
        // GET: Events
        public ActionResult Index()

        {

            Database1Entities3 selectevent = new Database1Entities3();
            var cl = from m in selectevent.Addevents
                     orderby m.EventID
                     select m;
            return View(cl);
        }
     
        public ActionResult AdminEvents()
        {
            Database1Entities3 selectevent = new Database1Entities3();
            var cl = from m in selectevent.Addevents
                     orderby m.Date
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
            string message = "";
            Database1Entities3 s = new Database1Entities3();

            if (ModelState.IsValid)
            {
                var isExist = IsEventNameExist(modem.EventName);
                if (isExist)
                {
                    ModelState.AddModelError("EventNameExist", "Event Name already exist");
                    return View(modem);
                }

                s.Addevents.Add(modem);
                s.SaveChanges();

                message = "New Event Added Successfully";
                ViewBag.Message = message;
                return View();
                // return RedirectToAction("AdminEvents", "Events");

            }
            else
            {
                return View();
            }
        }

        public ActionResult EditEvent(string eventname)
        {
            return View();
        }
        [HttpPost]

        public ActionResult EditEvent(string EventName, String Region, String Description, String Date, String City, String TypeofEvent, String NumberOfOfficialsNeeded)
        {
            if (ModelState.IsValid)
            {
                string message = "";
                Database1Entities3 edit = new Database1Entities3();
                Addevent p = edit.Addevents.Find(EventName);

                edit.Configuration.ValidateOnSaveEnabled = false;
                p.Region = Region;
                p.Description = Description;
                p.Date = Date;
                p.City = City;
                p.TypeofEvent = TypeofEvent;
                p.NumberOfOfficialsNeeded = NumberOfOfficialsNeeded;
                edit.SaveChanges();
                message = "Event Edited Successfully";
                ViewBag.Message = message;
                return View();
            }
            else
            {
                return View();
            }
        }
        public ActionResult UserRegistration(string eventname, string email)
        {
          
            return View();
        }
        [HttpPost]
        public ActionResult UserRegistration(UserEvent modem)
        {
            Database1Entities3 s = new Database1Entities3();
            string message = "";
           
            if (ModelState.IsValid)
            {
                var isExist = IsEmailidExist(modem.EmailID);
                if (isExist)
                {
                   
                        s.UserEvents.Add(modem);
                        s.SaveChanges();
                        message = "You are successfully registered for this event..!";
                        ViewBag.Message = message;
                        return View();
                     

                   

                }
                ModelState.AddModelError("InValidEmail", "Enter your email");
                return View(modem);


            }
            else
            {
                return View();
            }
        }
        public ActionResult UserEvents()

        {

            Database1Entities3 selectevent = new Database1Entities3();
            var cl = from m in selectevent.Addevents
                     orderby m.EventID
                     select m;
            return View(cl);
        }

        public ActionResult UsersRegistered(string eventname)

        {


            Database1Entities3 selectevent = new Database1Entities3();
            var cl = from m in selectevent.UserEvents
                     orderby m.UserRegId
                     where m.EventName==eventname
                     select m;
            return View(cl);

        }

        public ActionResult UserDetails(string email)
        {
            Database1Entities3 selectUser = new Database1Entities3();
            var bl = from m in selectUser.Users
                     orderby m.UserID
                     where m.EmailID == email
                     select m;
            return View(bl);
        }
        public ActionResult AssignRole(string Email,string eventname)
        {
            UserEvent model = new UserEvent();
            model.EmailID = Email;
            return View(model);
        }
        [HttpPost]
        public ActionResult AssignRole(UserEvent modem)
        {
            if (ModelState.IsValid)
            {
                string message = "";
                Database1Entities3 s = new Database1Entities3();
                var k = s.UserEvents.Where(a => a.EmailID == modem.EmailID).FirstOrDefault();
                var v = s.UserEvents.Where(a => a.EventName == modem.EventName).FirstOrDefault();
                if (k != null && v != null)
                    {
                    k.Roles = modem.Roles;
                    s.SaveChanges();
                    ModelState.Clear();
                    SendVerificationLinkEmail(modem.EmailID, modem.Roles, modem.EventName);
                    message = "User roles are successfully assigned and notified for user";
                    ViewBag.Message = message;
                    return View();
                  
                }
                    else
                    {
                        ModelState.AddModelError("InValidEventname", "User not Registered for this event");
                        return View(modem);

                    }

                
            

            }
            return View(modem);
        }


        [NonAction]
        public bool IsEventNameExist(string eventName)
        {
            using (Database1Entities3 dc = new Database1Entities3())
            {
                var v = dc.Addevents.Where(a => a.EventName == eventName).FirstOrDefault();
                return v != null;
            }
        }
        public bool IsEmailidExist(string email)
        {
            using (Database1Entities3 dc = new Database1Entities3())
            {
                string Emailid = @HttpContext.User.Identity.Name;
                var v =(Emailid == email);
                return v ;
            }
        }
        public bool IsEventAdded(string eventName)
        {
            using (Database1Entities3 dc = new Database1Entities3())
            {
                var v = dc.UserEvents.Where(a => a.EventName == eventName).FirstOrDefault();
                return v != null;
            }
        }
        public void SendVerificationLinkEmail(string emailID, string roles, string eventname)
        {
            var verifyUrl = "/Login/Login/";
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
            var fromEmail = new MailAddress("kamalakaruppala6@gmail.com", "RDANZI");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "9677282349";
            String subject = "You have been assigned a role for the event:"+eventname+"..!";
            string body = "<br/><br/>Hello,<br/><br/>You have been assigned to the event: " + eventname + "<br/><br/>The role you have been assigned is for: " + roles +
                 "<br/><br/>For more information, please click on the link below to login into your account " +
                 "<br/><br/><a href=" + link + " '> " + link + "</a>";
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };
            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }

    }
}




   



