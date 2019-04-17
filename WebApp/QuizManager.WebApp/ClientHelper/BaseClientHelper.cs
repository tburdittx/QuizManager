using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace QuizManager.WebApp.ClientHelper
{
    public class BaseClientHelper
    {
        public static HttpClient WebApiClient = new HttpClient();

        public BaseClientHelper()
        {
            WebApiClient.BaseAddress = new Uri("http://localhost:18811/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public HttpResponseMessage GethttpClient(string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:18811/api/");

                var responseTask = client.GetAsync(url);
                responseTask.Wait();

                HttpResponseMessage result;
                return result = responseTask.Result;
            }
        }

        public HttpResponseMessage PostHttpClient(string url, HttpContent entity)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:18811/api/");

                var responseTask = client.PostAsJsonAsync(url, entity);
                responseTask.Wait();

                HttpResponseMessage result;
                return result = responseTask.Result;
            }
        }
    }
}
