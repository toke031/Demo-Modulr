using Juice_Demo_Modulr.Core.Shared;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Juice_Demo_Modulr.Core.Requests
{
    public class CreateBeneficiaryAccountRequest : RequestBase
    {
        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("birthDate")]
        public string BirthDate { get; set; }

        [Required(ErrorMessage = "DefaultReference is required!")]
        [JsonProperty("defaultReference")]
        public string DefaultReference { get; set; }

        [Required(ErrorMessage = "DestinationIdentifier is required!")]
        [JsonProperty("destinationIdentifier")]
        public DestinationIdentifier DestinationIdentifier { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [StringLength(50, ErrorMessage = "ExternalReference is too long (max 50 characters)!")]
        [JsonProperty("externalReference")]
        public string ExternalReference { get; set; }

        [JsonProperty("idToReplace")]
        public string IdToReplace { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("qualifier")]
        public string Qualifier { get; set; }

    }
}
