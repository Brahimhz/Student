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
    
    public partial class Departement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Departement()
        {
            this.DomaineFormations = new HashSet<DomaineFormation>();
        }
    
        public int Id { get; set; }
        public string NomDepartement { get; set; }
        public int EtablissementId { get; set; }
    
        public virtual Etablissement Etablissement { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DomaineFormation> DomaineFormations { get; set; }
    }
}
