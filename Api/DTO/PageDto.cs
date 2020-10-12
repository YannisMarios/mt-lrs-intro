using System.Collections.Generic;

namespace Api.DTO
{
    public class PageDto<T> where T : class
    {
        /// <summary>
        /// A list of items
        /// </summary>
        public IEnumerable<T> Items { get; set; }

        /// <summary>
        /// Number of pages
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// Total number of items
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Current page number
        /// </summary>
        public int? CurrentPage { get; set; }

    }
}
