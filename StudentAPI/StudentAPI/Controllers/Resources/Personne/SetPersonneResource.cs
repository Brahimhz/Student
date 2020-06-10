using System;
using System.Collections.Generic;

namespace StudentAPI.Controllers.Resources
{
    public class SetPersonneResource
    {

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Genre { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual ICollection<int> DocumentPartages { get; set; }
        public SetPersonneResource()
        {
            DocumentPartages = new HashSet<int>();

        }
    }
}
