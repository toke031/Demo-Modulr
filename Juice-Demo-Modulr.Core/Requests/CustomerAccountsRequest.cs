using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Juice_Demo_Modulr.Core.Requests
{
    public class CustomerAccountsRequest : RequestBase
    {
        [JsonProperty("content")]
        public MainAccData MainAccountData { get; set; }
    }

    public class MainAccData
    {
        [Required(ErrorMessage = "CustomerId is required!")]
        [JsonProperty("cid")]
        public string CustomerId { get; set; }

        [Required(ErrorMessage = "Currency is required!")]
        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
