using Juice_Demo_Modulr.Core.Common.Enums;
using Juice_Demo_Modulr.Core.Shared;
using Newtonsoft.Json;

namespace Juice_Demo_Modulr.Core.Responses
{
    //public class CreatePaymentResponse : ResponseBase
    //{
    //    [JsonProperty("id")]
    //    public string Id { get; set; }

    //    [JsonProperty("approvalStatus")]
    //    public string ApprovalStatus { get; set; }

    //    [JsonProperty("message")]
    //    public string Message { get; set; }

    //    [JsonProperty("schemeInfo")]
    //    public SchemeInfo SchemeInfo { get; set; }

    //    [JsonProperty("status")]
    //    public string Status { get; set; }

    //    [JsonProperty("createdDate")]
    //    public string CreatedDate { get; set; }

    //    [JsonProperty("externalReference")]
    //    public string ExternalReference { get; set; }

    //    [JsonProperty("details")]
    //    public object[] Details { get; set; }
    //}

    //public class SchemeInfo
    //{
    //    [JsonProperty("id")]
    //    public string Id { get; set; }

    //    [JsonProperty("message")]
    //    public string Message { get; set; }

    //    [JsonProperty("name")]
    //    public string Name { get; set; }

    //    [JsonProperty("responseCode")]
    //    public string ResponseCode { get; set; }
    //}

    public class CreatePaymentResponse : ResponseBase
    {

        [JsonProperty("details")]
        public ModulrPaymentDetails Details { get; set; }

        [JsonProperty("createdDate")]
        public string CreatedDate { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("approvalStatus")]
        public string ApprovalStatus { get; set; }
    }

    public class ModulrPaymentDetails
    {
        [JsonProperty("sourceAccountId")]
        public string SourceAccountId { get; set; }

        [JsonProperty("destinationType")]
        public TypeOfDestinationIdentifier DestinationType { get; set; }

        [JsonProperty("destination")]
        public DestinationPaymentIdentifier Destination { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("amount")]
        public float Amount { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }
    }
}
