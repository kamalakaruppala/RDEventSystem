//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RDEvent.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Addevent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Addevent()
        {
            this.UserEvents = new HashSet<UserEvent>();
        }
    
        public int EventID { get; set; }
        public string EventName { get; set; }
        public string Region { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string City { get; set; }
        public string TypeofEvent { get; set; }
        public string NumberOfOfficialsNeeded { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserEvent> UserEvents { get; set; }
    }
}
