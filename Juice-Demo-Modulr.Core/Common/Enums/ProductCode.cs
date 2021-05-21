using System.ComponentModel;

namespace Juice_Demo_Modulr.Core.Common.Enums
{
    public enum ProductCode
    {
        [Description("GBP Visa Business")]
        O120001M = 1,
        [Description("GBP Visa Consumer")]
        O120001P,
        [Description("EUR Visa Business")]
        O120001N,
        [Description("EUR Visa Consumer")]
        O120001Q
    }
}
