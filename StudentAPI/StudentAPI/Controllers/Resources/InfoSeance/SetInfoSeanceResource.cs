using System;

namespace StudentAPI.Controllers.Resources.InfoSeance
{
    public class SetInfoSeanceResource
    {
        public string Type { get; set; }
        public int SeanceId { get; set; }
        public Nullable<int> SalleId { get; set; }
        public int MatiereId { get; set; }
        public Nullable<int> EnseignatId { get; set; }
        public int JourneeId { get; set; }
        public int PlanningId { get; set; }

    }
}
