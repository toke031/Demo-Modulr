using Juice_Demo_Modulr.Core.Shared;
using Newtonsoft.Json;

namespace Juice_Demo_Modulr.Core.Responses
{
    public class CreateCustomerAccountResponse : ResponseBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("balance")]
        public string Balance { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("customerId")]
        public string CustomerId { get; set; }

        [JsonProperty("customerName")]
        public string CustomerName { get; set; }

        [JsonProperty("createdDate")]
        public string CreatedDate { get; set; }

        [JsonProperty("directDebit")]
        public string DirectDebit { get; set; }

        [JsonProperty("accessGroups")]
        public string[] AccessGroups { get; set; }

        [JsonProperty("identifiers")]
        public Identifier[] Identifiers { get; set; }
    }

    public class Identifier
    {
        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("bic")]
        public string Bic { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("iban")]
        public string IBAN { get; set; }

        [JsonProperty("sortCode")]
        public string SortCode { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("countrySpecificDetails")]
        public CountryDetails CountrySpecificDetails { get; set; }
    }
}
