//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentDomain
{
    using System;
    using System.Collections.Generic;
    
    public partial class PlanningGroupe : Planning
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlanningGroupe()
        {
            this.PlanningSGroupes = new HashSet<PlanningSGroupe>();
        }
    
        public int SectionId { get; set; }
        public int PlanningSectionId { get; set; }
    
        public virtual Section Section { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlanningSGroupe> PlanningSGroupes { get; set; }
        public virtual PlanningSection PlanningSection { get; set; }
    }
}
