using Juice_Demo_Modulr.Core.Helpers;
using Juice_Demo_Modulr.Core.Responses;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Juice_Demo_Modulr.Core.Client
{
    public class ModulrClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _baseUrl;
        public ModulrClient(IHttpClientFactory factory = default)
        {
            _httpClientFactory = factory ?? new ServiceCollection()
                .AddHttpClient()
                .BuildServiceProvider()
                .GetService<IHttpClientFactory>();
            _baseUrl = "https://api-sandbox.modulrfinance.com/api-sandbox/";
        }

        #region Private methods
        public async Task<TResponse> GetAsync<TResponse>(string path) where TResponse : ResponseBase, new()
        {
            string query = GetEndpoint(path);
            HttpClient http = _httpClientFactory.CreateClient();
            http = SetHeaders(http);
            using HttpResponseMessage response = await http.GetAsync(query);
            string responseContent = await response.Content.ReadAsStringAsync();
            return await CreateResponse<TResponse>(response);
        }
        public async Task<TResponse> DeleteAsync<TResponse>(string path) where TResponse : ResponseBase, new()
        {
            string query = GetEndpoint(path);
            HttpClient http = _httpClientFactory.CreateClient();
            http = SetHeaders(http);
            http.DefaultRequestHeaders.Add("Method", "DELETE");
            using HttpResponseMessage response = await http.DeleteAsync(query);
            string responseContent = await response.Content.ReadAsStringAsync();
            return await CreateResponse<TResponse>(response);
        }
        public async Task<TResponse> PostAsync<TResponse>(string path, SerializableContent request) where TResponse : ResponseBase, new()
        {
            //SetCredentials(request);
            HttpContent body = null;
            string endpoint = GetEndpoint(path);

            string requestData;
            if (request != null)
            {
                requestData = request.ToJson();
                body = new StringContent(requestData, Encoding.UTF8, "application/json");
            }
            HttpClient http = _httpClientFactory.CreateClient();
            http = SetHeaders(http);
            using HttpResponseMessage response = await http.PostAsync(endpoint, body);
            requestData = await response.Content.ReadAsStringAsync();
            return await CreateResponse<TResponse>(response);
        }
        private HttpClient SetHeaders(HttpClient http)
        {
            string apiKey = ConfigurationManager.AppSettings["ModulrApiKey"];
            string secret = ConfigurationManager.AppSettings["ModulrSecret"];
            string httpDate = DateTime.UtcNow.ToUniversalTime().ToString("r");
            string nonce = Guid.NewGuid().ToString();
            http.DefaultRequestHeaders.Add("Date", httpDate);
            http.DefaultRequestHeaders.Add("x-mod-nonce", nonce);
            string signatureString = $"date: {httpDate}\nx-mod-nonce: {nonce}";
            string signature = GetSignature(secret, signatureString);
            http.DefaultRequestHeaders.Remove("Authorization");
            http.DefaultRequestHeaders.Add("Authorization", $"Signature keyId=\"{apiKey}\",algorithm=\"hmac-sha1\",headers=\"date x-mod-nonce\",signature=\"{signature}\"");
            return http;
        }
        public string GetSignature(string secret, string signatureString)
        {
            byte[] keyByte = Encoding.UTF8.GetBytes(secret);
            HMACSHA1 hmacsha1 = new HMACSHA1(keyByte);
            byte[] messageBytes = Encoding.UTF8.GetBytes(signatureString);
            byte[] hashmessage = hmacsha1.ComputeHash(messageBytes);
            var base64String = Convert.ToBase64String(hashmessage);
            string urldecode = HttpUtility.UrlEncode(base64String);
            Regex reg = new Regex(@"%[a-f0-9]{2}");
            string signature = reg.Replace(urldecode, m => m.Value.ToUpperInvariant());
            return signature;
        }

        private readonly JsonSerializer _serializer = new JsonSerializer
        {
            NullValueHandling = NullValueHandling.Ignore,
        };
        private async Task<TResponse> CreateResponse<TResponse>(HttpResponseMessage response) where TResponse : ResponseBase, new()
        {
            using Stream stream = await response.Content.ReadAsStreamAsync();
            using var reader = new StreamReader(stream);
            using var jsonReader = new JsonTextReader(reader);
            if (response.IsSuccessStatusCode)
            {
                TResponse result = _serializer.Deserialize<TResponse>(jsonReader);
                if (result != null)
                {
                    result.StatusCode = response.StatusCode;
                    return result;
                }
                else
                {
                    return new TResponse
                    {
                        StatusCode = response.StatusCode
                    };
                }
            }
            else
            {
                var d = _serializer.Deserialize<List<Exceptions.ModulrException>>(jsonReader);
                return new TResponse
                {
                    StatusCode = response.StatusCode,
                    Exception = d[0]
                };
            }
        }

        private string GetEndpoint(string path)
        {
            return string.Concat(_baseUrl, path);
        }
        #endregion
    }
}
