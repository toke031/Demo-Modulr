using Juice_Demo_Modulr.Core.Common.Enums;
using Juice_Demo_Modulr.Core.Shared;
using Juice_Demo_Modulr.Core.Validation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Juice_Demo_Modulr.Core.Requests
{
    public class CreateCustomerRequest : RequestBase
    {
        [CustomAttributeValidation("Type", new string[] { "LLC", "PLC" }, false, ErrorMessage = "CompanyRegNumber is mandatory for 'LLC' and 'PLC' types.")]
        [JsonProperty("companyRegNumber")]
        public string CompanyRegNumber { get; set; }

        [CustomAttributeValidation("Type", new string[] { "PCM_BUSINESS", "PCM_INDIVIDUAL" }, true, ErrorMessage = "ExpectedMonthlySpend is mandatory for all types except 'PCM_BUSINESS' and 'PCM_INDIVIDUAL'")]
        [JsonProperty("expectedMonthlySpend")]
        public int ExpectedMonthlySpend { get; set; }

        [StringLength(50, ErrorMessage = "ExternalReference is too long (max 50 characters)!")]
        [JsonProperty("externalReference")]
        public string ExternalReference { get; set; }

        [CustomAttributeValidation("Type", new string[] { "INDIVIDUAL", "PCM_INDIVIDUAL", "PCM_BUSINESS" }, true, ErrorMessage = "IndustryCode is mandatory for all types except 'INDIVIDUAL', 'PCM_BUSINESS' and 'PCM_INDIVIDUAL'")]
        [JsonProperty("industryCode")]
        public string IndustryCode { get; set; }

        [Required(ErrorMessage = "LegalEntity is required!")]
        [JsonProperty("legalEntity")]
        public string LegalEntity { get; set; } //can be: ['GB','IE']

        [CustomAttributeValidation("Type", new string[] { "INDIVIDUAL", "PCM_INDIVIDUAL" }, true, ErrorMessage = "Name  is mandatory for all types except 'INDIVIDUAL' and 'PCM_INDIVIDUAL'")]
        [JsonProperty("name")]
        public string Name { get; set; }

        //[JsonProperty("status")]
        //public string Status { get; set; } //ACTIVE

        [CustomAttributeValidation("Type", new string[] { "PCM_INDIVIDUAL", "PCM_BUSINESS" }, true, ErrorMessage = "TcsVersion  is mandatory for all types except 'PCM_BUSINESS' and 'PCM_INDIVIDUAL'")]
        [JsonProperty("tcsVersion")]
        public int TCSVersion { get; set; }

        [JsonProperty("tradingAddress")]
        public Address TradingAddress { get; set; }

        [JsonProperty("registeredAddress")]
        public Address RegisteredAddress { get; set; }

        private CustomerType type;


        [Required(ErrorMessage = "Type is required!")]
        [JsonProperty("type")]
        public string Type
        {
            get { return type.ToString(); }
            set
            {
                Enum.TryParse(value.ToString(), out CustomerType cType);
                type = cType;
            }
        }

        //private VerificationStatus verificationStatus;

        //[JsonProperty("verificationStatus")]
        //public string VerificationStatus
        //{
        //    get { return verificationStatus.ToString(); }
        //    set
        //    {
        //        Enum.TryParse(value.ToString(), out VerificationStatus vStatus);
        //        verificationStatus = vStatus;
        //    }
        //}

        //[JsonProperty("delegate")]
        //public Core.Shared.Delegate Delegate { get; set; }
        [CustomAttributeValidation("Type", new string[] { "PCM_BUSINESS" }, true, ErrorMessage = "Associates is mandatory for all types except 'PCM_BUSINESS'")]
        [JsonProperty("associates")]
        public List<Associate> Associates { get; set; }

        [JsonProperty("documentInfo")]
        public List<DocumentInfo> DocumentInfo { get; set; }

    }
}
