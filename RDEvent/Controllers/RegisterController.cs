using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Web.Mvc;
using RDEvent.Models;
using System.Net;
using Mvc.Mailer;
using AngleSharp.Io;

namespace RDEvent.Controllers
{
    public class RegisterController : Controller
    {
        //Registration Action

        // GET: Register
        [HttpGet]
      
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind(Exclude = "IsEmailVerified,ActivationCode")]User user)
        {
            bool Status = false;
            string message = "";
            if (ModelState.IsValid)
            {
                var isExist = IsEmailExist(user.EmailID);
                if(isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email already exist");
                    return View(user);
                }
                //ActivationCode
                user.ActivationCode = Guid.NewGuid();
                //Password Hashing
                user.Password = Crypto.Hash(user.Password);
                user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword);
                user.IsEmailVerified = false;
                using(Database1Entities dc= new Database1Entities())
                {
                    dc.Users.Add(user);
                    dc.SaveChanges();
                    //Send Email to user
                    SendVerificationLinkEmail(user.EmailID, user.ActivationCode.ToString());
                    message = "Registration Successfully Done.Account Activation Link" +
                        "has been sent to your Email id";
                    Status = true;
                }

            }
            else
            {
                message = "Invalid Request";
            }
            ViewBag.Message = message;
            ViewBag.Status = Status;
            return View(user);
        }
     
     
        public ActionResult Verification()
        {
            return View();
        }
        [HttpGet]
        public ActionResult VerifyAccount(string id)
        {
            bool Status = false;
            using (Database1Entities dc = new Database1Entities())
            {
                dc.Configuration.ValidateOnSaveEnabled = false;
                var v = dc.Users.Where(a => a.ActivationCode == new Guid(id)).FirstOrDefault();
                if (v != null)
                {
                    v.IsEmailVerified = true;
                    dc.SaveChanges();
                    Status = true;
                }
                else
                {
                    ViewBag.Message = "Invalid Request";
                }
            }
            ViewBag.Status = Status;
            return View();
        }

        [NonAction]
        public bool IsEmailExist(string emailID)
        {
            using (Database1Entities dc = new Database1Entities())
            {
                var v = dc.Users.Where(a => a.EmailID == emailID).FirstOrDefault();
                return v != null;
            }
        }

        [NonAction]
        public void SendVerificationLinkEmail(string emailID, string activationCode)
        {
            var verifyUrl = "/Register/VerifyAccount/" + activationCode;
            var link =Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
            var fromEmail = new MailAddress("kamalakaruppala6@gmail.com", "RDANZI");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "9677282349";
            String subject = "Your Account is Successfully Created";
            string body = "<br/><br/>We are excited to tell you that your account as volunteer for RDANZI" +
                "is successfully created.Please click on below link to verify your account" +
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

