//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentAPI.Core.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class InfoSeance
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public int SeanceId { get; set; }
        public Nullable<int> SalleId { get; set; }
        public int MatiereId { get; set; }
        public Nullable<int> EnseignatId { get; set; }
        public int JourneeId { get; set; }
        public int PlanningId { get; set; }

        public virtual Salle Salle { get; set; }
        public virtual Matiere Matiere { get; set; }
        public virtual Enseignant Enseignat { get; set; }
        public virtual Seance Seance { get; set; }
        public virtual Journee Journee { get; set; }
        public virtual Planning Planning { get; set; }
    }
}
