using System;

namespace StudentAPI.Controllers.Resources
{
    public class GetPersonneResource
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
