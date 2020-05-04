using StudentAPI.Extensions;

namespace StudentAPI.Core.Models.Query
{
    public class TimeTableQuery : IQueryObject
    {

        public string SchoolYear { get; set; }
        public string Cycle { get; set; }
        public string Semester { get; set; }
        public string Specility { get; set; }
        public string ClassNbr { get; set; }
        public string SortBy { get; set; }
        public bool IsAsc { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}
