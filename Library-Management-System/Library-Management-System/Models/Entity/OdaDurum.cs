//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Library_Management_System.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class OdaDurum
    {
        public int DurumID { get; set; }
        public Nullable<int> OdaNo { get; set; }
    
        public virtual OdaBilgisi OdaBilgisi { get; set; }
    }
}
