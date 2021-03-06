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
    
    public partial class Matiere
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Matiere()
        {
            this.ResultatMatieres = new HashSet<ResultatMatiere>();
            this.InfoSeances = new HashSet<InfoSeance>();
        }
    
        public int Id { get; set; }
        public double Coefficient { get; set; }
        public double Credit { get; set; }
        public int UnitePedagogiqueId { get; set; }
        public int MatiereRefId { get; set; }
        public int NiveauSpecialiteId { get; set; }
    
        public virtual UnitePedagogique UnitePedagogique { get; set; }
        public virtual MatiereRef MatiereRef { get; set; }
        public virtual NiveauSpecialite NiveauSpecialite { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResultatMatiere> ResultatMatieres { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InfoSeance> InfoSeances { get; set; }
    }
}
