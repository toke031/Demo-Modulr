using Juice_Demo_Modulr.Core.Shared;
using Newtonsoft.Json;

namespace Juice_Demo_Modulr.Core.Responses
{
    public class CreateBeneficiaryAccountResponse : ResponseBase
    {
        [JsonProperty("accessGroups")]
        public string[] AccessGroups { get; set; }

        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("approvalRequestId")]
        public string ApprovalRequestId { get; set; }

        [JsonProperty("approvalRequired")]
        public bool ApprovalRequired { get; set; }

        [JsonProperty("approvalStatus")]
        public string ApprovalStatus { get; set; }

        [JsonProperty("birthDate")]
        public string BirthDate { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("customerId")]
        public string CustomerId { get; set; }

        [JsonProperty("defaultReference")]
        public string DefaultReference { get; set; }

        [JsonProperty("destinationIdentifier")]
        public DestinationIdentifier DestinationIdentifier { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("externalReference")]
        public string ExternalReference { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("idToReplace")]
        public string IdToReplace { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("qualifier")]
        public string Qualifier { get; set; }

        [JsonProperty("redirectedDestination")]
        public DestinationIdentifier RedirectedDestination { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("updated")]
        public string Updated { get; set; }
    }
}
