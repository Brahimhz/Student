using StudentAPI.Extensions;

namespace StudentAPI.Core.QueryObject
{
    public class EtudiantQuery : IQueryObject
    {
        public string SortBy { get; set; }
        public bool IsAsc { get; set; }

        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}
