namespace StudentAPI.Controllers.Resources
{
    public class GetSeanceResource
    {
        public int Id { get; set; }
        public ModuleResource Module { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public string Time { get; set; }
        public string Day { get; set; }
        public int TimeTableId { get; set; }
    }
}
