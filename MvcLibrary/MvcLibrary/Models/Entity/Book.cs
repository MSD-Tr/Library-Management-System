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
    
    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            this.Movements = new HashSet<Movement>();
        }
    
        public int BookID { get; set; }
        public string Name { get; set; }
        public Nullable<byte> CategoryID { get; set; }
        public Nullable<int> AuthorID { get; set; }
        public string YearOfPublication { get; set; }
        public string Publisher { get; set; }
        public string NumberOfPages { get; set; }
        public Nullable<bool> Situation { get; set; }
    
        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Movement> Movements { get; set; }
    }
}
