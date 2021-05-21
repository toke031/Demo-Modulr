using Juice_Demo_Modulr.Core.Shared;
using Newtonsoft.Json;

namespace Juice_Demo_Modulr.Core.Responses
{
    public class CreateRuleResponse : ResponseBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        [JsonProperty("customerId")]
        public string CustomerId { get; set; }

        [JsonProperty("data")]
        public RuleDetails Data { get; set; }
    }
}
