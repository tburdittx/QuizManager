using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using QuizManager.Entities;
using QuizManager.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace QuizManager.WebApp.ClientHelper
{
    public class QuetionsQueryClientHelper:BaseClientHelper
    {
       
        public IEnumerable<QuestionsViewModel> GetAllQuestions(int id)
        {
            // var result = GetAllQuestions();
            IEnumerable<QuestionsViewModel> questions;
            // int id = 1;
            string readAllQuestionsUrl = $"questions/ReadQuestionByCategoryId/{id}";
            var result = GethttpClient(readAllQuestionsUrl);

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
              // ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return questions;
        }
    }
}
