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
        CategoryQueryClientHelper categoryQueryClientHelper = new CategoryQueryClientHelper();

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
                 Question=incomingModel.Question,
                 CategoryId=incomingModel.CategoryId,
                 OptionA=incomingModel.OptionA,
                 OptionB=incomingModel.OptionB,
                 OptionC=incomingModel.OptionC,
                 OptionD=incomingModel.OptionD,
                 Answer=incomingModel.Answer,
                 Explanation=incomingModel.Explanation
            };

            HttpResponseMessage response = CommandClientHelper.WebApiClient.PostAsJsonAsync("http://localhost:18811/api/questions/CreateQuestion", entity).Result;
            return this.View("Success");
        }

        public IActionResult GetListOfQuestions (int id)
        {
            var questions = questionsQueryClientHelper.GetAllQuestions(id);
            return this.View(questions);
        }

        public IActionResult EditQuestion(int id)
        {
            var question = this.questionsQueryClientHelper.GetQuestionById(id);

            var category = this.categoryQueryClientHelper.GetCategoryById(question.CategoryId);

            QuestionsViewModel model = new QuestionsViewModel
            {
                 Id=question.Id,
                 CategoryId=question.CategoryId,
                 CategoryName=category.Name,
                 Question=question.Question,
                 OptionA=question.OptionA,
                 OptionB=question.OptionB,
                 OptionC=question.OptionC,
                 OptionD=question.OptionD,
                 Answer=question.Answer,
                 Explanation=question.Explanation
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult EditQuestion(QuestionsViewModel incomingModel)
        {
            Questions entity = new Questions
            {
                Id=incomingModel.Id,
                Question = incomingModel.Question,
                CategoryId = incomingModel.CategoryId,
                OptionA = incomingModel.OptionA,
                OptionB = incomingModel.OptionB,
                OptionC = incomingModel.OptionC,
                OptionD = incomingModel.OptionD,
                Answer = incomingModel.Answer,
                Explanation = incomingModel.Explanation
            };

            HttpResponseMessage response = CommandClientHelper.WebApiClient.PostAsJsonAsync($"http://localhost:18811/api/questions/editQuestion/{incomingModel.Id}", entity).Result;

            return this.View("Success");
        }

        public IActionResult DeleteCategory(int id)
        {
            var category = this.categoryQueryClientHelper.GetCategoryById(id);

            CategoryViewModel model = new CategoryViewModel
            {
                 Id=category.Id,
                 Name=category.Name,
                 Description=category.Description
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult DeleteCategory(Category model)
        {
            HttpResponseMessage response = CommandClientHelper.WebApiClient.PostAsJsonAsync($"http://localhost:18811/api/category/DeleteQuestionCategoryById/{model.Id}", model.Id).Result;

            return this.View("Success");
        }

        public IActionResult DeleteQuestion(int id)
        {
            var question = this.questionsQueryClientHelper.GetQuestionById(id);

            QuestionsViewModel model = new QuestionsViewModel
            {
                Id = question.Id,
                Question = question.Question,
                CategoryId = question.CategoryId,
                OptionA = question.OptionA,
                OptionB = question.OptionB,
                OptionC = question.OptionC,
                OptionD = question.OptionD,
                Answer = question.Answer,
                Explanation = question.Explanation
            };
            return this.View(model);
        }

        [HttpPost]
        public IActionResult DeleteQuesiton(Questions incomingModel)
        {
            HttpResponseMessage response = CommandClientHelper.WebApiClient.PostAsJsonAsync($"http://localhost:18811/api/questions/DeleteQuestion/{incomingModel.Id}", incomingModel.Id).Result;

            return this.View("Success");
        }

        public IActionResult CreateCategory()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult CreateCategory(CategoryViewModel incomingModel)
        {
            Category category = new Category
            {
                Name = incomingModel.Name,
                Description = incomingModel.Description
            };

            HttpResponseMessage response = CommandClientHelper.WebApiClient.PostAsJsonAsync($"http://localhost:18811/api/category/CreateCategory", category).Result;

            return this.View("Success");
        }
    }
}
