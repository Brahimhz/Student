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

    public partial class Parcour
    {
        public int Id { get; set; }
        public int EtudientId { get; set; }
        public int NiveauSpecialiteId { get; set; }
        public Nullable<int> SousGroupeId { get; set; }
        public Nullable<int> ResultatId { get; set; }
        public DateTime LastUpdate { get; set; }


        public virtual Etudiant Etudient { get; set; }
        public virtual NiveauSpecialite NiveauSpecialite { get; set; }
        public virtual SousGroupe SousGroupe { get; set; }
        public virtual Resultat Resultat { get; set; }
    }
}