using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using QuizManager.Entities;
namespace QuizManager.WebApp.ClientHelper
{
    public class QuestionsCommandClientHelper:BaseClientHelper 
    {
        
           
        
        //public string CreateQuestion(Questions entity)
        //{
        //    Questions questions = new Questions();
        //    string createQuestion = $"http://localhost:18811/api/questions/CreateQuestion";
            
        //    var result = PostHttpClient(createQuestion, entity);

        //    //If success received   
        //    if (result.IsSuccessStatusCode)
        //    {
        //        var readTask = result.Content.ReadAsAsync<Questions>();
        //        readTask.Wait();

        //        questions = readTask.Result;
        //    }
        //    else
        //    {
        //        //Error response received   
        //        // ModelState.AddModelError(string.Empty, "Server error try after some time.");
        //    }
        //    return questions;
        //}
    }
}
