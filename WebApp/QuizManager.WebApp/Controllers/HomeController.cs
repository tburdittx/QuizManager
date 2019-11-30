using System;
using System.Diagnostics;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizManager.Entities;
using QuizManager.WebApp.ClientHelper;
using QuizManager.WebApp.Models;

namespace QuizManager.WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private QuestionsQueryClientHelper questionsQueryClientHelper = new QuestionsQueryClientHelper();
        private CategoryQueryClientHelper categoryQueryClientHelper = new CategoryQueryClientHelper();

        //public IActionResult Index()
        //{
        //    // this.Categories();
        //    return View();
        //}

        public IActionResult Index()
        {
            var categoryOptions = categoryQueryClientHelper.GetCategories();
            return View(categoryOptions);
        }
        
        public IActionResult GetAllQuestionsByCategoryId(int id)
        {
            var questions = questionsQueryClientHelper.GetAllQuestions(id);
            return View("Questions2", questions);
        }

        [HttpPost]
        //[Authorize(Roles = "Restricted,Edit")]
        
        public IActionResult GetScore(QuestionsViewModel models)
        {
           Questions questions = questionsQueryClientHelper.GetQuestionById(models.Id);

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
            return View("GetScore");

        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
     //   [Authorize(Roles = "Edit")]
        public IActionResult CreateQuestion(int categoryId)
        {
            QuestionsViewModel model = new QuestionsViewModel
            {
                CategoryId=categoryId
            };

            return View(model);
        }

        [HttpPost]
       // [Authorize(Roles = "Edit")]
        public IActionResult CreateQuestion(QuestionsViewModel incomingModel)
        {
            var user = this.GetCurrentLoggedInUser();
            Questions entity = new Questions
            {
                Question = incomingModel.Question,
                CategoryId = incomingModel.CategoryId,
                OptionA = incomingModel.OptionA,
                OptionB = incomingModel.OptionB,
                OptionC = incomingModel.OptionC,
                OptionD = incomingModel.OptionD,
                Answer = incomingModel.Answer,
                Explanation = incomingModel.Explanation,
                 CreatedDate=DateTime.Now,
                 CreatedBy=user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };

            HttpResponseMessage response = CommandClientHelper.WebApiClient.PostAsJsonAsync("http://localhost:18811/api/questions/CreateQuestion", entity).Result;
            return View("Success");
        }

      // [Authorize(Roles = "Edit")]
        public IActionResult GetListOfQuestions(int id)
        {
            var questions = questionsQueryClientHelper.GetAllQuestions(id);

            QuestionsViewModel model = new QuestionsViewModel
            {
                ListOfQuestions = questions,
                CategoryId = id
            };

            return View(model);
        }

      //  [Authorize(Roles = "Edit")]
        public IActionResult EditQuestion(int id)
        {
            var question = questionsQueryClientHelper.GetQuestionById(id);

            var category = categoryQueryClientHelper.GetCategoryById(question.CategoryId);

            QuestionsViewModel model = new QuestionsViewModel
            {
                Id = question.Id,
                CategoryId = question.CategoryId,
                CategoryName = category.Name,
                Question = question.Question,
                OptionA = question.OptionA,
                OptionB = question.OptionB,
                OptionC = question.OptionC,
                OptionD = question.OptionD,
                Answer = question.Answer,
                Explanation = question.Explanation
            };

            return View(model);
        }

        [HttpPost]
      //  [Authorize(Roles = "Edit")]
        public IActionResult EditQuestion(QuestionsViewModel incomingModel)
        {
            var user = this.GetCurrentLoggedInUser();

            Questions entity = new Questions
            {
                Id = incomingModel.Id,
                Question = incomingModel.Question,
                CategoryId = incomingModel.CategoryId,
                OptionA = incomingModel.OptionA,
                OptionB = incomingModel.OptionB,
                OptionC = incomingModel.OptionC,
                OptionD = incomingModel.OptionD,
                Answer = incomingModel.Answer,
                Explanation = incomingModel.Explanation,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };

            HttpResponseMessage response = CommandClientHelper.WebApiClient.PostAsJsonAsync($"http://localhost:18811/api/questions/editQuestion/{incomingModel.Id}", entity).Result;

            return View("Success");
        }

     //   [Authorize(Roles = "Edit")]
        public IActionResult DeleteCategory(int id)
        {
            var category = categoryQueryClientHelper.GetCategoryById(id);

            CategoryViewModel model = new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };

            return View(model);
        }

        [HttpPost]
      //  [Authorize(Roles = "Edit")]
        public IActionResult DeleteCategory(Category model)
        {
            HttpResponseMessage response = CommandClientHelper.WebApiClient.PostAsJsonAsync($"http://localhost:18811/api/category/DeleteQuestionCategoryById/{model.Id}", model.Id).Result;

            return View("Success");
        }

      //  [Authorize(Roles = "Edit")]
        public IActionResult DeleteQuestion(int id)
        {
            var question = questionsQueryClientHelper.GetQuestionById(id);

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
            return View(model);
        }

        [HttpPost]
       // [Authorize(Roles = "Edit")]
        public IActionResult DeleteQuesiton(Questions incomingModel)
        {
            HttpResponseMessage response = CommandClientHelper.WebApiClient.PostAsJsonAsync($"http://localhost:18811/api/questions/DeleteQuestion/{incomingModel.Id}", incomingModel.Id).Result;

            return View("Success");
        }

        [Authorize(Roles = "Edit")]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
     //   [Authorize(Roles = "Edit")]
        public IActionResult CreateCategory(CategoryViewModel incomingModel)
        {
            var user = this.GetCurrentLoggedInUser();

            Category category = new Category
            {
                Name = incomingModel.Name,
                Description = incomingModel.Description,
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };

            HttpResponseMessage response = CommandClientHelper.WebApiClient.PostAsJsonAsync($"http://localhost:18811/api/category/CreateCategory", category).Result;

            return View("Success");
        }

      //  [Authorize(Roles = "Edit")]
        public IActionResult EditCategory(int id)
        {
            var category = categoryQueryClientHelper.GetCategoryById(id);

            CategoryViewModel model = new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };

            return View(model);
        }

        [HttpPost]
      //  [Authorize(Roles = "Edit")]
        public IActionResult EditCategory(CategoryViewModel incomingModel)
        {
            var user = this.GetCurrentLoggedInUser();

            Category category = new Category
            {
                Id = incomingModel.Id,
                Name = incomingModel.Name,
                Description = incomingModel.Description,
                ModifiedDate = DateTime.Now,
                ModifiedBy = user,
            };

            HttpResponseMessage response = CommandClientHelper.WebApiClient.PostAsJsonAsync("http://localhost:18811/api/category/EditCategory/{incomingModel.id}", category).Result;

            return View("Success");
        }

        public string GetCurrentLoggedInUser()
        {
           return this.User.Identity.Name;
        }
    }
}
