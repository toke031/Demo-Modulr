using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Juice_Demo_Modulr.Core.Shared
{
    public class Address
    {

        [Required(ErrorMessage = "AddressLine1 is required!")]
        [JsonProperty("addressLine1")]
        public string AddressLine1 { get; set; }

        [JsonProperty("addressLine2")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Country is required!")]
        [JsonProperty("country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "PostCode is required!")]
        [JsonProperty("postCode")]
        public string PostCode { get; set; }

        [Required(ErrorMessage = "PostTown is required!")]
        [JsonProperty("postTown")]
        public string PostTown { get; set; }
    }
}
