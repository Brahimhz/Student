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

    public partial class Seance
    {
        public int Id { get; set; }
        public string Heure { get; set; }
        public int JourneeId { get; set; }
        public Nullable<int> InfoSeanceId { get; set; }

        public virtual Journee Journee { get; set; }
        public virtual InfoSeance InfoSeances { get; set; }
    }
}
