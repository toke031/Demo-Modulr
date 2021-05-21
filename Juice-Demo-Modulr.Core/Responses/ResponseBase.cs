using System.Net;

namespace Juice_Demo_Modulr.Core.Responses
{
    public class ResponseBase
    {
        /// <summary>
        /// Gets the http status code.
        /// </summary>
        /// <value>The status code.</value>
        public HttpStatusCode StatusCode { get; internal set; }

        public bool IsSuccessStatusCode
        {
            get { return StatusCode == HttpStatusCode.OK; }
        }

        /// <summary>
        /// The Error
        /// </summary>
        public Exceptions.ModulrException Exception;
    }
}
