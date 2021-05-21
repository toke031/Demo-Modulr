using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Juice_Demo_Modulr.Core.Requests
{
    public class CreateCustomerAccountRequest : RequestBase
    {
        [Required(ErrorMessage = "Currency is required!")]
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [StringLength(50, ErrorMessage = "ExternalRef is too long (max 50 characters)!")]
        [JsonProperty("externalReference")]
        public string ExternalReference { get; set; } //Account's Alias

        [JsonProperty("productCode")]
        public string ProductCode { get; set; }
    }
}
