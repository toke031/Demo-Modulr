using Juice_Demo_Modulr.Core.Helpers;
using Juice_Demo_Modulr.Core.Shared;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Juice_Demo_Modulr.Core.Requests
{
    public class CreatePaymentRequest : SerializableContent
    {
        [Required(ErrorMessage = "Amount is required!")]
        [JsonProperty("amount")]
        public float Amount { get; set; }

        [Required(ErrorMessage = "Currency is required!")]
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("destination")]
        public DestinationPaymentIdentifier Destination { get; set; }

        [JsonProperty("externalReference")]
        public string ExternalReference { get; set; }

        [JsonProperty("fxQuoteId")]
        public string FXQuoteId { get; set; }

        [JsonProperty("paymentDate")]
        public string PaymentDate { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [Required(ErrorMessage = "SourceAccountId is required!")]
        [JsonProperty("sourceAccountId")]
        public string SourceAccountId { get; set; }
    }
}
