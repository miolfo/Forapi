using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Net.Http;
using System.Net.Http.Headers;
using System;

namespace ApiAccesser
{
    class Program
    {
        public static void Main(string[] args)
        {
            Task T = MainTask();
            T.Wait();
        }
        public static async Task MainTask()
        {
            string baseUri = "http://star-api.herokuapp.com/";
            string requestUri = "api/v1/stars/Sun";
            string[] result = await ApiAccess.ApiCallAsync(baseUri, requestUri);
            Console.WriteLine(result[1]);
        }
    }
}
