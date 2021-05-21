using Newtonsoft.Json;

namespace Juice_Demo_Modulr.Core.Shared
{
    public class CountryDetails
    {
        [JsonProperty("bankAddress")]
        public string BankAddress { get; set; }

        [JsonProperty("bankBranchCode")]
        public string BankBranchCode { get; set; }

        [JsonProperty("bankBranchName")]
        public string BankBranchName { get; set; }

        [JsonProperty("bankCity")]
        public string BankCity { get; set; }

        [JsonProperty("bankCode")]
        public string BankCode { get; set; }

        [JsonProperty("bankName")]
        public string BankName { get; set; }

        [JsonProperty("business")]
        public bool Business { get; set; }

        [JsonProperty("chineseId")]
        public string ChineseId { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; }
    }
}
