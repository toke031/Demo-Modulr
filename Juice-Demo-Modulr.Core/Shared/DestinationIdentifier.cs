using Juice_Demo_Modulr.Core.Common.Enums;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Juice_Demo_Modulr.Core.Shared
{
    public class DestinationIdentifier
    {
        [Required(ErrorMessage = "AccountNumber is required!")]
        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("bic")]
        public string Bic { get; set; }

        [JsonProperty("countrySpecificDetails")]
        public CountryDetails CountrySpecificDetails { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("iban")]
        public string Iban { get; set; }

        [JsonProperty("sortCode")]
        public string SortCode { get; set; }


        private TypeOfDestinationIdentifier type;

        [Required(ErrorMessage = "Type is required!")]
        [JsonProperty("type")]
        public string Type
        {
            get { return type.ToString(); }
            set
            {
                Enum.TryParse(value.ToString(), out TypeOfDestinationIdentifier DItype);
                type = DItype;
            }
        }
    }

    public class DestinationPaymentIdentifier : DestinationIdentifier
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
