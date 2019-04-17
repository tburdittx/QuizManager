using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace QuizManager.WebApp.ClientHelper
{
    public class CommandClientHelper
    {
        public static HttpClient WebApiClient = new HttpClient();

        public CommandClientHelper()
        {
            WebApiClient.BaseAddress = new Uri("http://localhost:18811/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
