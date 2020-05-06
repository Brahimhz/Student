namespace StudentAPI.Controllers.Resources
{
    public class ModuleResource : SchoolInformationResource
    {
        public string Name { get; set; }
        public string AbvNom { get; set; }
        public string Unite { get; set; }
        public int Coefficient { get; set; }
        public int Credit { get; set; }
    }
}
