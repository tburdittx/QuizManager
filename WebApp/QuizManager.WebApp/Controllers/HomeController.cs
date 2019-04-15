using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuizManager.WebApp.Models;
using QuizManager.Entities;

namespace QuizManager.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            this.Categories();
            return View();
        }

        public IActionResult Categories()
        {
            IEnumerable<CategoryViewModel> categoryOptions;

            string getCategories = "category/readallcategories";
            var result = this.httpClient(getCategories);

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
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }

            return this.View(categoryOptions);
        }

        public IActionResult GetAllQuestionsByCategoryId()
        {
            // var result = GetAllQuestions();
            IEnumerable<Questions> questions;
            int id = 1;
            string readAllQuestionsUrl = $"questions/ReadQuestionByCategoryId/{id}";
            var result = this.httpClient(readAllQuestionsUrl);

            //If success received   
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Questions>>();
                readTask.Wait();

                questions = readTask.Result;
            }
            else
            {
                //Error response received   
                questions = Enumerable.Empty<Questions>();
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }

            QuestionsViewModel model = new QuestionsViewModel();

            model.ListOfQuestions = new List<Questions>();

            foreach (var item in questions)
            {
                model.ListOfQuestions.Add(item);
            }


            return this.View("Questions", model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public HttpResponseMessage httpClient(string url)
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

    }
}
