using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RDEvent.Models
{
    public class SkatingRoles
    {
        public int SkatingId { get; set; }
        public string SkatingRole { get; set; }
        public bool IsChecked { get; set; }
    }
    public class NonSkatingRoles
    {
        public int NonSkatingId { get; set; }
        public string NonSkatingRole { get; set; }
        public bool IsChecked { get; set; }
    }
}