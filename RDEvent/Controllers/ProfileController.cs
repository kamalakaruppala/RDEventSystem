using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RDEvent.Models;
namespace RDEvent.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
      
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Register model)
        {
            Database1Entities db = new Database1Entities();
            if (ModelState.IsValid)
            {
                db.Registers.Add(model);
                db.SaveChanges();


                return View();
            }
            else
            {
                return View();
            }
        }
        public ActionResult Experience()
        {
            List<Roles> RolesList = new List<Roles>();
            RolesList.Add(new Roles { RolesID = 1, RolesList = "Head Referee", IsAvailable = false });
            RolesList.Add(new Roles { RolesID = 1, RolesList = "Jammer Referee", IsAvailable = false });
            RolesList.Add(new Roles { RolesID = 1, RolesList = "Inside Pack Referee", IsAvailable = false });
            RolesList.Add(new Roles { RolesID = 1, RolesList = "Outside Pack Referee", IsAvailable = false });
            RolesList.Add(new Roles { RolesID = 1, RolesList = "Alternate Referee", IsAvailable = false });
            RolesList.Add(new Roles { RolesID = 1, RolesList = "TournamentHead Referee", IsAvailable = false });
            RolesList.Add(new Roles { RolesID = 1, RolesList = "Crew Head Referee", IsAvailable = false });
            RolesList.Add(new Roles { RolesID = 1, RolesList = "Games Official", IsAvailable = false });
            ViewBag.RolesList = RolesList;
            return View();
        }
        [HttpPost]
        public ActionResult Experience(Register model)
        {
            Database1Entities db = new Database1Entities();
            if (ModelState.IsValid)
            {
                db.Registers.Add(model);
                db.SaveChanges();


                return View();
            }
            else
            {
                return View();
            }

        }
        public ActionResult NonSkating()
        {
            List<NonRoles> NonRolesList = new List<NonRoles>();
            NonRolesList.Add(new NonRoles { NonRolesID = 1, NonRolesList = "Head NSO", IsAvailable = false });
            NonRolesList.Add(new NonRoles { NonRolesID = 1, NonRolesList = "Penalty Wrangler", IsAvailable = false });
            NonRolesList.Add(new NonRoles { NonRolesID = 1, NonRolesList = "Penalty Wrangler", IsAvailable = false });
            NonRolesList.Add(new NonRoles { NonRolesID = 1, NonRolesList = "Inside White Board", IsAvailable = false });
            NonRolesList.Add(new NonRoles { NonRolesID = 1, NonRolesList = "Outside White Board", IsAvailable = false });
            NonRolesList.Add(new NonRoles { NonRolesID = 1, NonRolesList = "Jam Timer", IsAvailable = false });
            NonRolesList.Add(new NonRoles { NonRolesID = 1, NonRolesList = "ScoreKeeper", IsAvailable = false });
            NonRolesList.Add(new NonRoles { NonRolesID = 1, NonRolesList = "Scoreboard Opertor", IsAvailable = false });
            NonRolesList.Add(new NonRoles { NonRolesID = 1, NonRolesList = "Penalty Box Manager", IsAvailable = false });
            NonRolesList.Add(new NonRoles { NonRolesID = 1, NonRolesList = "Penalty Box Timer", IsAvailable = false });
            NonRolesList.Add(new NonRoles { NonRolesID = 1, NonRolesList = "Lineup Tracker", IsAvailable = false });
            NonRolesList.Add(new NonRoles { NonRolesID = 1, NonRolesList = "Alternate NSO", IsAvailable = false });
            NonRolesList.Add(new NonRoles { NonRolesID = 1, NonRolesList = "Tournament Head NSO", IsAvailable = false });
            NonRolesList.Add(new NonRoles { NonRolesID = 1, NonRolesList = "Alternate NSO", IsAvailable = false });
            ViewBag.RolesList = NonRolesList;
            return View();
        }
        [HttpPost]
        public ActionResult NonSkating(Register model)
        {
            Database1Entities db = new Database1Entities();
            if (ModelState.IsValid)
            {
                db.Registers.Add(model);
                db.SaveChanges();


                return View();
            }
            else
            {
                return View();
            }
        }
        public ActionResult Availability()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Availability(Register model)
        {
            Database1Entities db = new Database1Entities();
            if (ModelState.IsValid)
            {
                db.Registers.Add(model);
                db.SaveChanges();


                return View();
            }
            else
            {
                return View();
            }
        }
    }
}

    
