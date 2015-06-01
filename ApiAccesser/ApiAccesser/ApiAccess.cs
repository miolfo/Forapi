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
        public static async Task<string[]> ApiCallAsync(string baseUri, string requestUri)
        {
            string responseString;
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = await client.GetAsync(requestUri);
                responseString = await response.Content.ReadAsStringAsync();
            }
            Console.WriteLine(response.ToString());
            string[] responseArray = new string[] {response.ToString(), responseString };
            return responseArray;
        }
    }

}
