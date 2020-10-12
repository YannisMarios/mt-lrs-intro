using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace Api.DTO
{
    public class SearchUserParamsDto
    {
        /// <summary>
        /// The search string
        /// </summary>
        [JsonProperty("searchString")]
        public string SearchString { get; set; } = "";

        /// <summary>
        /// The page index
        /// </summary>
        [JsonProperty("pageIndex")]
        [Required, Range(0, int.MaxValue)]
        public int PageIndex { get; set; }

        /// <summary>
        /// The page size
        /// </summary>
        [JsonProperty("pageSize")]
        [Required, Range(1, int.MaxValue)]
        public int PageSize { get; set; }
    }
}
