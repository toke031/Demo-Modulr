using Newtonsoft.Json;

namespace Juice_Demo_Modulr.Core.Responses
{
    public class CreateVirtualCardResponse : ResponseBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("createDate")]
        public string CreateDate { get; set; }

        [JsonProperty("cvv2")]
        public string CVV2 { get; set; }

        [JsonProperty("externalRef")]
        public string ExternalRef { get; set; }

        [JsonProperty("maxLimit")]
        public double MaxLimit { get; set; }

        [JsonProperty("pan")]
        public string Pan { get; set; }
    }
}
