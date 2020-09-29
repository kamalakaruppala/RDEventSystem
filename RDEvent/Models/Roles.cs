using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RDEvent.Models
{
    public class Roles
    {
        public int RolesID { get; set; }
        public string RolesList{ get; set; }
        public bool IsAvailable { get; set; }
    }
    public class NonRoles
    {
        public int NonRolesID { get; set; }
        public string NonRolesList { get; set; }
        public bool IsAvailable { get; set; }
    }
}