//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.ExpenseModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class LookUpDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LookUpDetail()
        {
            this.Expenses = new HashSet<Expens>();
            this.Expenses1 = new HashSet<Expens>();
            this.Expenses2 = new HashSet<Expens>();
        }
    
        public int Id { get; set; }
        public Nullable<int> LookUpId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedAt { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Expens> Expenses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Expens> Expenses1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Expens> Expenses2 { get; set; }
    }
}
