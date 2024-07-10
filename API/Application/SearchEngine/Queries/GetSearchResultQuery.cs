using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SearchEngine.Queries
{
    public class GetSearchResultQuery: IRequest<OperationResult<List<SearchResult>>>
    {
        public string SearchItem { get; set; }
    }
}
