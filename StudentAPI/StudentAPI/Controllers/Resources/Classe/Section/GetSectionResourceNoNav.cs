using StudentAPI.Controllers.Resources.NiveauSpecialite;

namespace StudentAPI.Controllers.Resources.Section
{
    public class GetSectionResourceNoNav
    {


        public int Id { get; set; }
        public string RefSection { get; set; }

        public virtual NiveauSpecialiteResource NiveauSpecialite { get; set; }


    }
}
