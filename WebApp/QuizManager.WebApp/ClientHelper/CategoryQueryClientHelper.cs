using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using QuizManager.WebApp.Models;

namespace QuizManager.WebApp.ClientHelper
{
    public class CategoryQueryClientHelper:BaseClientHelper
    {
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
    }
}
