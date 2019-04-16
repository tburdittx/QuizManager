using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuizManager.WebApp.Models;
using QuizManager.Entities;
using Newtonsoft.Json.Linq;

namespace QuizManager.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
           // this.Categories();
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

        public IActionResult GetAllQuestionsByCategoryId(int id)
        {
            // var result = GetAllQuestions();
            IEnumerable<QuestionsViewModel> questions;
           // int id = 1;
            string readAllQuestionsUrl = $"questions/ReadQuestionByCategoryId/{id}";
            var result = this.httpClient(readAllQuestionsUrl);

            //If success received   
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<QuestionsViewModel>>();
                readTask.Wait();

                questions = readTask.Result;
            }
            else
            {
                //Error response received   
                questions = Enumerable.Empty<QuestionsViewModel>();
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            
            //IEnumerable<QuestionsViewModel> model;

            //model.ListOfQuestions = new List<Questions>();

            //model.ListOfQuestions = questions;
            


            return this.View("Questions2", questions);
        }

        [HttpPost]
        public IActionResult GetScore(QuestionsViewModel models)
        {
            Questions questions = new Questions();
            string getQuestionsById = $"questions/readquestionbyid/{models.Id}";

            var result = this.httpClient(getQuestionsById);

            //If success received   
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Questions>();
                readTask.Wait();

                questions = readTask.Result;
            }
            else
            {
                //Error response received   
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }

            //questions is coming back with the whole question from the database. 



            QuestionsViewModel questionResult = new QuestionsViewModel
            {
                Id=models.Id,
                CategoryId=questions.CategoryId,
                Question = questions.Question,
                OptionA = questions.OptionA,
                OptionB = questions.OptionB,
                OptionC = questions.OptionC,
                OptionD = questions.OptionD,
                Answer = questions.Answer,
                Explanation = questions.Explanation,
                AnswerInput=models.AnswerInput

            };
  if (models.AnswerInput==questions.Answer)
            {
                questionResult.Correct = "You got the right answer!";
            }
            else
            {
questionResult.Correct = "You got the wrong answer!";
            }
            return this.View("GetScore", questionResult);

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
