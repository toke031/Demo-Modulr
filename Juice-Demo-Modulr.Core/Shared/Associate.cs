using Juice_Demo_Modulr.Core.Common.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Juice_Demo_Modulr.Core.Shared
{
    public class Associate
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("applicant")]
        public bool Applicant { get; set; }

        [JsonProperty("dateOfBirth")]
        public string DateOfBirth { get; set; }

        [JsonProperty("ownership")]
        public int OwnerShip { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        private TypeOfAssociate type;

        [JsonProperty("type")]
        public string Type
        {
            get { return type.ToString(); }
            set
            {
                Enum.TryParse(value.ToString(), out TypeOfAssociate aType);
                type = aType;
            }
        }
        [JsonProperty("verificationStatus")]
        public VerificationStatus VerificationStatus { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("middleName")]
        public string MiddleName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("documentInfo")]
        public List<DocumentInfo> DocumentInfo { get; set; }

        [JsonProperty("homeAddress")]
        public Address HomeAddress { get; set; }
    }
}
