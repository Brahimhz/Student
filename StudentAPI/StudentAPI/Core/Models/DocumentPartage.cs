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

    public partial class DocumentPartage
    {
        public int Id { get; set; }
        public string NomDoc { get; set; }
        public string TypeDoc { get; set; }
        public int PersonneId { get; set; }
        public Nullable<int> MatiereRefId { get; set; }
        public DateTime LastUpdate { get; set; }


        public virtual Personne Personne { get; set; }
        public virtual MatiereRef MatiereRef { get; set; }
    }
}
