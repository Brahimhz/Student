using StudentAPI.Extensions;

namespace StudentAPI.Core.QueryObject
{
    public class RequestQuery : IQueryObject
    {
        public string Filter { get; set; }
        public string SortBy { get; set; }
        public bool IsAsc { get; set; }

        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}
