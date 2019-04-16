using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuizManager.WebApp.ClientHelper
{
    public class BaseClientHelper
    {
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

                var responseTask = client.PostAsync(url, entity);
                responseTask.Wait();

                HttpResponseMessage result;
                return result = responseTask.Result;
            }
        }
    }
}
