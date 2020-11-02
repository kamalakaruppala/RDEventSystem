using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using AngleSharp.Common;
using RDEvent.Models;
namespace RDEvent.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Database1Entities3 selectevent = new Database1Entities3();
            var cl = from m in selectevent.Addevents
                     orderby m.Date
                     select m;

            return View(cl);
        }


        public ActionResult Users()
        {
            string email = @HttpContext.User.Identity.Name;
            Database1Entities3 selectevent = new Database1Entities3();
            var cl = from m in selectevent.UserEvents
                     orderby m.UserRegId
                     where m.EmailID == email
                     select m;

            return View(cl);
        }

        public ActionResult RegisteredEvents(string eventname)
        {
            Database1Entities3 selectevent = new Database1Entities3();
            var cl = from m in selectevent.Addevents
                     orderby m.Date
                     where m.EventName == eventname
                     select m;

            return View(cl);

        }


        [Authorize]
        public ActionResult Admin()
        {
            Database1Entities3 selectevent = new Database1Entities3();
            var cl = from m in selectevent.Addevents
                     orderby m.Date
                     select m;
            return View(cl);
        }
        public ActionResult ProfileDetails()
        {
            string email = @HttpContext.User.Identity.Name;
            Database1Entities3 selectevent = new Database1Entities3();
            var cl = from m in selectevent.Users
                     where m.EmailID == email
                     select m;
            return View(cl);
        }
        public ActionResult DetailedProfiles(string email)
        {

            Database1Entities3 selectevent = new Database1Entities3();
            var cl = from m in selectevent.Users
                     where m.EmailID == email
                     select m;
            return View(cl);
        }
        public ActionResult PersonalDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonalDetails([Bind(Exclude = "Password,ConfirmPassword")] string FirstName, string LastName, string Street, string City, string Region, string Postal, string MinistryofBackground, string PhoneNumber)

        {
            string email = @HttpContext.User.Identity.Name;

            using (Database1Entities3 dc = new Database1Entities3())
            {
                User edit = dc.Users.Find(email);
                edit.FirstName = FirstName;
                edit.LastName = LastName;
                edit.Street = Street;
                edit.City = City;
                edit.Region = Region;
                edit.Postal = Postal;
                edit.MinistryofBackground = MinistryofBackground;
                edit.PhoneNumber = PhoneNumber;
                dc.Configuration.ValidateOnSaveEnabled = false;
                dc.SaveChanges();

                return RedirectToAction("Experience", "Home");
            }
        }
        public ActionResult Experience()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Experience([Bind(Exclude = "Password,ConfirmPassword")] string SkRoles, string SkExperience, string SkCertificationLevels, string SkAdditionalSkills)

        {
            string email = @HttpContext.User.Identity.Name;
            string message = "";
            using (Database1Entities3 dc = new Database1Entities3())
            {
                User edit = dc.Users.Find(email);
                edit.SkRoles = SkRoles;
                edit.SkExperience = SkExperience;
                edit.SkCertificationLevels = SkCertificationLevels;
                edit.SkAdditionalSkills = SkAdditionalSkills;

                dc.Configuration.ValidateOnSaveEnabled = false;
                dc.SaveChanges();
                message = "Your details are updated successfully";
                ViewBag.Message = message;
                return View();
            }

        }

        public ActionResult NonSkatting()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult NonSkatting([Bind(Exclude = "Password,ConfirmPassword")] string NSkRoles, string NSkExperience, string NSkCertificationLevels, string NSkAdditionalSkills)

        {
            string email = @HttpContext.User.Identity.Name;
            string message = "";
            using (Database1Entities3 dc = new Database1Entities3())
            {
                User edit = dc.Users.Find(email);
                edit.NSkRoles = NSkRoles;
                edit.NSkExperience = NSkExperience;
                edit.NSkCertificationLevels = NSkCertificationLevels;
                edit.NSkAdditionalSkills = NSkAdditionalSkills;

                dc.Configuration.ValidateOnSaveEnabled = false;
                dc.SaveChanges();
                message = "Your details are updated successfully";
                ViewBag.Message = message;
                return View();
            }

        }
        public ActionResult UserProfiles()

        {

            Database1Entities3 selectuser = new Database1Entities3();
            var kl = from k in selectuser.Users
                     orderby k.EmailID
                     select k;
            return View(kl);
        }
        public ActionResult AddUsers(string Email)
        {
            UserEvent model = new UserEvent();
            model.EmailID = Email;
            return View(model);
        }
        [HttpPost]
        public ActionResult AddUsers(UserEvent modem)
        {
            Database1Entities3 s = new Database1Entities3();
            string message = "";


            if (ModelState.IsValid)
            {
                var IsExist = IsEventExist(modem.EventName);
                if (IsExist)
                {
                    var k = s.UserEvents.Where(a => a.EmailID == modem.EmailID).FirstOrDefault();
                    var v = s.UserEvents.Where(a => a.EventName == modem.EventName).FirstOrDefault();
                    if (k!=null && v!=null)
                    {
                        ModelState.AddModelError("InValidUser", "User is already registerd into this event");
                        return View(modem);
                    }
                    s.UserEvents.Add(modem);
                    s.SaveChanges();
                    message = "Successfully added user for this event and notified for user";
                    ViewBag.Message = message;
                    SendVerificationLinkEmail(modem.EmailID,modem.Roles,modem.EventName);
                    message = "Registration Successful. Account activation link" +
                        " has been sent to your Email";
                    ModelState.Clear();
                    return View();

                }
                ModelState.AddModelError("InValidEventname", "Event does not exist");
                return View(modem);



            }
            else
            {
                return View();
            }
        }
      
        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult PrivacyPolicy()
        {
            return View();
        }
        public ActionResult TermsOfUse()
        {
            return View();
        }
        [NonAction]
        public bool IsEventExist(string eventName)
        {
            using (Database1Entities3 dc = new Database1Entities3())
            {
                var v = dc.Addevents.Where(a => a.EventName == eventName).FirstOrDefault();
                return v != null;
            }
        }

        public void SendVerificationLinkEmail(string emailID, string roles,string eventname)
        {
            var verifyUrl = "/Login/Login/" ;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
            var fromEmail = new MailAddress("kamalakaruppala6@gmail.com", "RDANZI");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "9677282349";
            String subject = "You have been added to the event:"+eventname+"..!";
            string body = "<br/><br/>Hello,<br/><br/>You have been assigned to the event: " + eventname+ "<br/><br/>The role you have been assigned is for: " + roles+
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
        //RdanziAdmin2020

    }

}