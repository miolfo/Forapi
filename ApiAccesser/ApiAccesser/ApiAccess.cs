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
        /*PRIVATE VARIABLES*/
        private static HttpResponseMessage response;
        private string baseUri;
        private string requestUri;
        private string responseString;

        /*PUBLIC GETTERS AND SETTERS*/
        public string BaseUri
        {
            get
            {
                return baseUri;
            }
            set
            {
                //TODO: parse valid url
                baseUri = value;
            }
        }

        public string RequestUri
        {
            get
            {
                return requestUri;
            }
            set
            {
                //TODO: parse valid url
                requestUri = value;
            }
        }

        public string ResponseString
        {
            get
            {
                return responseString;
            }
        }

        public string HttpResponse
        {
            get
            {
                return response.ToString();
            }
        }

        /*PUBLIC METHODS*/
        public ApiAccess(string baseURI, string requestURI)
        {
            baseUri = baseURI;
            requestUri = requestURI;
        }

        //Public method for accessing api
        public async Task<string> GetApiResponseAsync()
        {
            string parsedResponse = "";
            string[] res = await ApiCallAsync();

            return res[1];
        }

        

        /*PRIVATE METHODS*/
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


    }

}
