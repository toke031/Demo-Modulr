using Newtonsoft.Json;

namespace Juice_Demo_Modulr.Core.Shared
{
    public class Delegate
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string DelegateName { get; set; }

        [JsonProperty("partner")]
        public string Partner { get; set; }

        [JsonProperty("roleId")]
        public string RoleId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("externalReference")]
        public string ExternalReference { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("updated")]
        public string Uploaded { get; set; }
    }
}
