using Juice_Demo_Modulr.Core.Shared;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Juice_Demo_Modulr.Core.Requests
{
    public class CreateRuleRequest : RequestBase
    {
        [Required(ErrorMessage = "AccountId is required!")]
        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        [JsonProperty("customerId")]
        public string CustomerId { get; set; }

        [Required(ErrorMessage = "Data is required!")]
        [JsonProperty("data")]
        public RuleDetails Data { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Type is required!")]
        [JsonProperty("type")]
        public string Type { get; set; }
    }


}
