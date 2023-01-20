namespace ProductApiDemo.Models
{
    public class PagedResult<T> where T:class
    {
        public PagedResult(int page, int totalCount, string nextPage, IEnumerable<T> items) 
        {
            Page = page;
            TotalCount = totalCount;
            NextPage = nextPage;
            Items = items;
        }

        /// <summary>
        /// Current page number
        /// </summary>
        /// <example>1</example>
        public int Page { get; }

        /// <summary>
        /// Total item count
        /// </summary>
        /// <example>100</example>
        public int TotalCount { get; }

        /// <summary>
        /// Path to next page
        /// </summary>
        /// <example>/Products/Search?page=1</example>
        public string NextPage { get; }

        /// <summary>
        /// List of products
        /// </summary>
        public IEnumerable<T> Items { get; }
    }
}
