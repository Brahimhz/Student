using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StudentAPI.Controllers.Resources.TimeTableResource
{
    public class GetTimeTableResource : SchoolInformationResource
    {
        public ICollection<SeanceResource> Seances { get; set; }

        public GetTimeTableResource()
        {
            Seances = new Collection<SeanceResource>();
        }
    }
}
