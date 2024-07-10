
namespace Domain.Models
{
    public class SearchResult
    {
        public SearchResult(object result, string category)
        {
            Id = Guid.NewGuid();
            Result = result;
            Category = category;
        }

        public Guid Id { get; private set; }
        public object Result { get; private set; }
        public string Category { get; private set; }

        public static SearchResult CreateSearchResult(object result, string category)
        {
            return new SearchResult(result, category);
        }

    }
}
