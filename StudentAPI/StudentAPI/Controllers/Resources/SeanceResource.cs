namespace StudentAPI.Controllers.Resources
{
    public class SeanceResource
    {
        public int Id { get; set; }
        public string Module { get; set; }
        public string Type { get; set; }
        public string Lieu { get; set; }
        public string Heure { get; set; }
        public string Jour { get; set; }
        public int TimeTableId { get; set; }
    }
}
