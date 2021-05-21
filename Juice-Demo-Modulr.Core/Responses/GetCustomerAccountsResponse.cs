using Newtonsoft.Json;

namespace Juice_Demo_Modulr.Core.Responses
{
    public class GetCustomerAccountsResponse : ResponseBase
    {
        [JsonProperty("content")]
        public BeneficiariesAccount[] Content { get; set; }
    }

    public class BeneficiariesAccount
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("externalReference")]
        public string ExternalReference { get; set; }
    }
}
