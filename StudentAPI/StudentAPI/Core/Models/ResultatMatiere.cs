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

    public partial class ResultatMatiere
    {
        public int Id { get; set; }
        public Nullable<double> NoteControl { get; set; }
        public Nullable<double> NoteExamen { get; set; }
        public Nullable<double> CreditMatiere { get; set; }
        public int MatiereId { get; set; }
        public int ResultatUniteId { get; set; }
        public DateTime LastUpdate { get; set; }


        public virtual Matiere Matiere { get; set; }
        public virtual ResultatUnite ResultatUnite { get; set; }
    }
}
