using Newtonsoft.Json;
using System;

namespace Juice_Demo_Modulr.Core.Exceptions
{
    [Serializable]
    public class ModulrException
    {
        [JsonProperty("exception")]
        public Exception[] Exception { get; set; }
    }

    public class Exception
    {
        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
