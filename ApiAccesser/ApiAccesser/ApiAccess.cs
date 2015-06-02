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
    public static class ApiAccess
    {
        /*PRIVATE VARIABLES*/
        private static HttpResponseMessage response;

        /*PUBLIC METHODS*/

        //Public method for accessing api
        public static async Task<ForapiResponseObject> GetApiResponseAsync(string baseURI, string requestURI)
        {
            ForapiResponseObject res = await ApiCallAsync(baseURI, requestURI);
            return res;
        }

        

        /*PRIVATE METHODS*/
        private static async Task<ForapiResponseObject> ApiCallAsync(string baseUri, string requestUri)
        {
            string responseString;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = await client.GetAsync(requestUri);
                responseString = await response.Content.ReadAsStringAsync();
            }
            ForapiResponseObject res = new ForapiResponseObject(response.ToString(), responseString, true);
            return res;
        }


    }

    public class ForapiResponseObject
    {
        /*PRIVATE VARIABLES*/
        private string httpResponseContent;
        private string response;
        private bool success;

        public ForapiResponseObject()
        {
            httpResponseContent = "";
            response = "";
            success = false;
        }

        public ForapiResponseObject(string httpResp, string resp, bool succ)
        {
            httpResponseContent = httpResp;
            response = resp;
            success = succ;
        }

        /*PUBLIC GETTERS AND SETTERS*/
        public string HttpResponse
        {
            get
            {
                return httpResponseContent;
            }
        }
        public string Response
        {
            get
            {
                return response;
            }
        }
        public bool Success
        {
            get
            {
                return success;
            }
        }
    }

}
