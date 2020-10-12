using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace Api.Models
{
    public class SearchUsersParams
    {
        /// <summary>
        /// The search string
        /// </summary>
        public string SearchString { get; set; } = "";

        /// <summary>
        /// The page index
        /// </summary>
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// The page size
        /// </summary>
        public int PageSize { get; set; } = 5;
    }
}
