namespace StudentAPI.Controllers.Resources
{
    public class GetSeanceResource
    {
        public int Id { get; set; }
        public ModuleResource Module { get; set; }
        public string Type { get; set; }
        public string Lieu { get; set; }
        public string Heure { get; set; }
        public string Jour { get; set; }
        public int TimeTableId { get; set; }
    }
}
