using Juice_Demo_Modulr.Core.Shared;
using Newtonsoft.Json;

namespace Juice_Demo_Modulr.Core.Requests
{
    public class InboundPaymentRequest : RequestBase
    {

        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        [JsonProperty("amount")]
        public float Amount { get; set; }

        [JsonProperty("numberOfTransactions")]
        public int NumberOfTransactions { get; set; }

        [JsonProperty("payeeDetail")]
        public Detail PayeeDetail { get; set; }

        [JsonProperty("payerDetail")]
        public Detail PayerDetail { get; set; }

        [JsonProperty("transactionDate")]
        public string TransactionDate { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class Detail
    {
        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("identifier")]
        public DestinationIdentifier Identifier { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

    }
}
