using System;

namespace StudentAPI.Controllers.Resources.Parcour
{
    public class SetParcourResource
    {
        public int EtudientId { get; set; }
        public int NiveauSpecialiteId { get; set; }
        public Nullable<int> SousGroupeId { get; set; }
        public Nullable<int> ResultatId { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
