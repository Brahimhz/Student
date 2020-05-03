namespace StudentAPI.Core.Models
{
    public class Seance
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Lieu { get; set; }
        public string Heure { get; set; }
        public string Jour { get; set; }

        public TimeTable TimeTable { get; set; }
        public int TimeTanleId { get; set; }
    }
}
