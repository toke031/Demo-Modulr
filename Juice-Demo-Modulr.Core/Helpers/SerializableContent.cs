using Newtonsoft.Json;

namespace Juice_Demo_Modulr.Core.Helpers
{
    public class SerializableContent
    {
        /// <summary>
        /// The null value handling.
        /// </summary>
        protected NullValueHandling NullValueHandling = NullValueHandling.Ignore;

        /// <summary>
        /// Returns a string that represents the current object in JSON format.
        /// </summary>
        /// <returns>System.String.</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings()
            {
                DateFormatString = "yyyy-MM-dd",
                NullValueHandling = this.NullValueHandling,
#if DEBUG
                Formatting = Formatting.Indented
#else
                Formatting = Formatting.None
#endif
            });
        }
    }
}
