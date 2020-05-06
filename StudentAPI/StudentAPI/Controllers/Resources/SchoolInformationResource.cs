using System;

namespace StudentAPI.Controllers.Resources
{
    public class SchoolInformationResource
    {
        public int Id { get; set; }
        public string Cycle { get; set; }
        public string Semester { get; set; }
        public string Speciality { get; set; }
        public string ClassNbr { get; set; }
        public string SchoolYear { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
