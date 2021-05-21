using Juice_Demo_Modulr.Core.Common.Enums;
using Juice_Demo_Modulr.Core.Shared;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Juice_Demo_Modulr.Core.Requests
{
    public class CreateVirtualCardRequest : RequestBase
    {
        [Required(ErrorMessage = "Expiry is required!")]
        [JsonProperty("expiry")]
        public string Expiry { get; set; }

        [Required(ErrorMessage = "ExternalRef is required!")]
        [StringLength(50, ErrorMessage = "ExternalRef is too long (max 50 characters)!")]
        [JsonProperty("externalRef")]
        public string ExternalRef { get; set; }

        [Required(ErrorMessage = "ExternalRef is required!")]
        [JsonProperty("cardHoleder")]
        public CardHolder CardHoleder { get; set; }

        [Required(ErrorMessage = "Limit is required!")]
        [JsonProperty("limit")]
        public double Limit { get; set; }

        private ProductCode productCode;

        [Required(ErrorMessage = "ProductCode is required!")]
        [JsonProperty("productCode")]
        public string ProductCode
        {
            get { return productCode.ToString(); }
            set
            {
                Enum.TryParse(value.ToString(), out ProductCode PC);
                productCode = PC;
            }
        }
    }
    public class CardHolder
    {
        [Required(ErrorMessage = "AddressDetail is required!")]
        [JsonProperty("addressDetail")]
        public Address AddressDetail { get; set; }

        [JsonProperty("dateOfBirth")]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessage = "FirstName is required!")]
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required!")]
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("mobileNumber")]
        public string MobileNumber { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
