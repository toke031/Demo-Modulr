using Juice_Demo_Modulr.Core.Shared;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Juice_Demo_Modulr.Core.Responses
{
    public class CreateCustomerResponse : ResponseBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("companyRegNumber")]
        public string CompanyRegNumber { get; set; }

        [JsonProperty("createdDate")]
        public string CreatedDate { get; set; }

        [JsonProperty("expectedMonthlySpend")]
        public int ExpectedMonthlySpend { get; set; }

        [JsonProperty("externalReference")]
        public string ExternalReference { get; set; }

        [JsonProperty("industryCode")]
        public string IndustryCode { get; set; }

        [JsonProperty("legalEntity")]
        public string LegalEntity { get; set; } //can be: ['GB','IE']

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; } //ACTIVE

        [JsonProperty("tcsVersion")]
        public int TCSVersion { get; set; }

        [JsonProperty("tradingAddress")]
        public Address TradingAddress { get; set; }

        [JsonProperty("registeredAddress")]
        public Address RegisteredAddress { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("verificationStatus")]
        public string VerificationStatus { get; set; }

        [JsonProperty("delegate")]
        public Core.Shared.Delegate Delegate { get; set; }

        [JsonProperty("associates")]
        public List<Associate> Associates { get; set; }

        [JsonProperty("documentInfo")]
        public List<DocumentInfo> DocumentInfo { get; set; }
    }
}
