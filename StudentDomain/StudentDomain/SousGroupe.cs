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
    
    public partial class SousGroupe
    {
        public int Id { get; set; }
        public int GroupeId { get; set; }
        public Nullable<int> PlanningSGroupeId { get; set; }
    
        public virtual Groupe Groupe { get; set; }
        public virtual PlanningSGroupe PlanningSGroupe { get; set; }
    }
}
