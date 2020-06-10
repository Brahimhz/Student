using StudentAPI.Core.Models;
using System;

namespace StudentAPI.Controllers.Resources.DocumentPartage
{
    public class GetDocumentPartageResource
    {
        public int Id { get; set; }
        public string NomDoc { get; set; }
        public string TypeDoc { get; set; }
        public GetPersonneResource Personne { get; set; }
        public MatiereRef MatiereRef { get; set; }
        public DateTime LastUpdate { get; set; }
        public DocumentFile Document { get; set; }


    }
}
