using System;

namespace StudentAPI.Controllers.Resources.DocumentPartage
{
    public class SetDocumentPartageResource
    {
        public int Id { get; set; }
        public string NomDoc { get; set; }
        public string TypeDoc { get; set; }
        public int PersonneId { get; set; }
        public Nullable<int> MatiereRefId { get; set; }
        public DateTime LastUpdate { get; set; }


    }
}
