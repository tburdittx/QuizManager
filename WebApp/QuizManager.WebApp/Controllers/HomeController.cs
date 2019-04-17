using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using QuizManager.Entities;
using QuizManager.WebApp.ClientHelper;
using QuizManager.WebApp.Models;

namespace QuizManager.WebApp.Controllers
{
    public class HomeController : Controller
    {
        QuestionsQueryClientHelper questionsQueryClientHelper = new QuestionsQueryClientHelper();
        QuestionsCommandClientHelper questionsCommandClientHelper = new QuestionsCommandClientHelper();
        CategoryQueryClientHelper categoryQueryClientHelper = new CategoryQueryClientHelper();
        CategoryCommandClientHelper categoryCommandClientHelper = new CategoryCommandClientHelper();

        public IActionResult Index()
        {
            // this.Categories();
            return View();
        }

        public IActionResult Categories()
        {

            var categoryOptions = this.categoryQueryClientHelper.GetCategories();
            return View(categoryOptions);
        }

        public IActionResult GetAllQuestionsByCategoryId(int id)
        {
            var questions = questionsQueryClientHelper.GetAllQuestions(id);

            return View("Questions2", questions);
        }

        [HttpPost]
        public IActionResult GetScore(QuestionsViewModel models)
        {
            Questions questions = this.questionsQueryClientHelper.GetQuestionById(models.Id);

            QuestionsViewModel questionResult = new QuestionsViewModel
            {
                Id = models.Id,
                CategoryId = questions.CategoryId,
                Question = questions.Question,
                OptionA = questions.OptionA,
                OptionB = questions.OptionB,
                OptionC = questions.OptionC,
                OptionD = questions.OptionD,
                Answer = questions.Answer,
                Explanation = questions.Explanation,
                AnswerInput = models.AnswerInput
            };
            if (models.AnswerInput == questions.Answer)
            {
                questionResult.Correct = "You got the right answer!";
            }
            else
            {
                questionResult.Correct = "You got the wrong answer!";
            }
            return View("GetScore", questionResult);

        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult CreateQuestion()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult CreateQuestion(QuestionsViewModel incomingModel)
        {
            Questions entity = new Questions
            {

            };

            HttpResponseMessage response = BaseClientHelper.WebApiClient.PostAsJsonAsync("questions/CreateQuestion", entity).Result;
            return this.View();
        }
    }
}
