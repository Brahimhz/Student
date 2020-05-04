using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StudentAPI.Controllers.Resources
{
    public class SaveTimeTableResource : SchoolInformationResource
    {
        public ICollection<int> Seances { get; set; }

        public SaveTimeTableResource()
        {
            Seances = new Collection<int>();
        }
    }
}
