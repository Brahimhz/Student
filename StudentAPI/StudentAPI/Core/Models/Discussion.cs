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
    using System.Collections.Generic;

    public partial class Discussion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Discussion()
        {
            this.Messages = new HashSet<Message>();
        }

        public int Id { get; set; }
        public System.DateTime DateDebut { get; set; }
        public Nullable<System.DateTime> DateFin { get; set; }
        public int RelationCommunicationId { get; set; }

        public DateTime LastUpdate { get; set; }

        public virtual RelationCommunication RelationCommunication { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages { get; set; }

    }
}
