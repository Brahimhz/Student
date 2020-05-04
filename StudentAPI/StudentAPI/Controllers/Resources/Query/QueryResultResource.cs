using System.Collections.Generic;

namespace StudentAPI.Controllers.Resources.Query
{
    public class QueryResultResource<T>
    {
        public int TotalItems { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
