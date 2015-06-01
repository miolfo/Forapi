using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Net.Http;
using System.Net.Http.Headers;

namespace ApiAccesser
{
    public class ApiAccess
    {
        private static HttpResponseMessage response;
        private string baseUri;
        private string requestUri;
        private string responseString;

        public ApiAccess(string baseURI, string requestURI)
        {
            baseUri = baseURI;
            requestUri = requestURI;
        }

        
        //TODO: privatize
        private async Task<string[]> ApiCallAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = await client.GetAsync(requestUri);
                responseString = await response.Content.ReadAsStringAsync();
            }
            string[] responseArray = new string[] {response.ToString(), responseString };
            return responseArray;
        }

        //Public method for accessing api
        public async Task<string> GetApiResponseAsync()
        {
            string parsedResponse = "";
            string[] res = await ApiCallAsync();

            return res[1];
        }
    }

}
