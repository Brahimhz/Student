using StudentAPI.Extensions;

namespace StudentAPI.Core.QueryObject
{
    public class ParcourQuery : IQueryObject
    {
        public int? DFId { get; set; }
        public int? FiliaireId { get; set; }
        public int? SpecialiteId { get; set; }
        public int? NivSpecId { get; set; }

        public string SortBy { get; set; }
        public bool IsAsc { get; set; }

        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}
