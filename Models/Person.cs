//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhoneContactMvcApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Person
    {
        public Person()
        {
            this.Address = new HashSet<Address>();
            this.Phone = new HashSet<Phone>();
        }
    
        public int PersonID { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
    
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Phone> Phone { get; set; }
    }
}
