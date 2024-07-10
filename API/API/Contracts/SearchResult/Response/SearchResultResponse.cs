namespace API.Contracts.SearchResult.Response
{
    public class SearchResultResponse
    {
        public Guid Id { get; set; }
        public object Result { get; set; }
        public string Category { get; set; }
    }
}
