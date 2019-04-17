using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using QuizManager.Entities;
using QuizManager.WebApp.Models;

namespace QuizManager.WebApp.ClientHelper
{
    public class CategoryQueryClientHelper
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

        public IEnumerable<CategoryViewModel> GetCategories()
        {
            IEnumerable<CategoryViewModel> categoryOptions;

            string getCategories = "category/readallcategories";
            var result = GethttpClient(getCategories);

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<CategoryViewModel>>();
                readTask.Wait();

                categoryOptions = readTask.Result;
            }
            else
            {
                //Error response received   
                categoryOptions = Enumerable.Empty<CategoryViewModel>();
               // ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }

            return categoryOptions;
        }

        public Category GetCategoryById(long id)
        {
            Category category = new Category();
            string getCategoryById = $"category/readcategorybyid/{id}";

            var result = GethttpClient(getCategoryById);

            //If success received   
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Category>();
                readTask.Wait();

                category = readTask.Result;
            }
            else
            {
                //Error response received   
                //ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return category;
        }
    }
}
