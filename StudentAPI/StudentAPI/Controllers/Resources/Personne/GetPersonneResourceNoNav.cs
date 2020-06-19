using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.Controllers.Resources.Personne
{
    public class GetPersonneResourceNoNav
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Genre { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public DateTime LastUpdate { get; set; }

    }
}
