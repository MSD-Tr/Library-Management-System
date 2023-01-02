//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcLibrary.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Penalty
    {
        public int PenaltyID { get; set; }
        public Nullable<int> UsersID { get; set; }
        public Nullable<System.DateTime> StartingDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<decimal> Money { get; set; }
        public Nullable<int> MovementID { get; set; }
    
        public virtual Movement Movement { get; set; }
        public virtual User User { get; set; }
    }
}
