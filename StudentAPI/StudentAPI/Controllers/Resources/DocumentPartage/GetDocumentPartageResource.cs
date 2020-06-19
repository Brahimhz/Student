using StudentAPI.Controllers.Resources.MatiereRef;
using StudentAPI.Controllers.Resources.NiveauSpecialite;
using StudentAPI.Controllers.Resources.Personne;
using StudentAPI.Core.Models;
using System;

namespace StudentAPI.Controllers.Resources.DocumentPartage
{
    public class GetDocumentPartageResource
    {
        public int Id { get; set; }
        public string NomDoc { get; set; }
        public string TypeDoc { get; set; }
        public GetPersonneResourceNoNav Personne { get; set; }
        public MatiereRefResourceNoNav MatiereRef { get; set; }
        public DateTime LastUpdate { get; set; }
        public DocumentFile Document { get; set; }
        public NiveauSpecialiteResource NiveauSpecialite { get; set; }



    }
}
