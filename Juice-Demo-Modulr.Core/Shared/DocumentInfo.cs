using Newtonsoft.Json;

namespace Juice_Demo_Modulr.Core.Shared
{
    public class DocumentInfo
    {
        [JsonProperty("fileName")]
        public string FileName { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("uploadedDate")]
        public string UploadedDate { get; set; }
    }
}
