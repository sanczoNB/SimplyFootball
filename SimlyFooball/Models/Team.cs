//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SimlyFooball.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Team
    {
        public Team()
        {
            this.Contracts = new HashSet<Contract>();
        }
    
        public long Id { get; set; }
        public string FullName { get; set; }
        public string NickName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int FoundYear { get; set; }
    
        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
