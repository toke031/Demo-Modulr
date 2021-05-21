using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Juice_Demo_Modulr.Core.Shared
{
    public class RuleDetails
    {
        [JsonProperty("daysToRun")]
        public string[] DaysToRun { get; set; }

        [Required(ErrorMessage = "Frequency is required!")]
        [JsonProperty("frequency")]
        public string Frequency { get; set; }

        [Required(ErrorMessage = "DestinationId is required!")]
        [JsonProperty("destinationId")]
        public string DestinationId { get; set; }

        [JsonProperty("balanceToLeave")]
        public string BalanceToLeave { get; set; }

        [JsonProperty("triggerBalance")]
        public string TriggerBalance { get; set; }
    }
}
