using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StudentAPI.Core.Models
{
    public class TimeTable : SchoolInformation
    {
        public ICollection<Seance> Seances { get; set; }

        public TimeTable()
        {
            Seances = new Collection<Seance>();
        }
    }
}
