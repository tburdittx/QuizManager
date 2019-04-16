using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using QuizManager.Entities;

namespace QuizManager.WebApp.Models
{
    public class QuestionsViewModel
    {
        public int Id { get; set; }
        public string Question { get; set; }

        public Category CategoryEntity { get; set; }

        [DisplayName("Option A")]
        public string OptionA { get; set; }

        [DisplayName("Option B")]
        public string OptionB { get; set; }

        [DisplayName("Option C")]
        public string OptionC { get; set; }

        [DisplayName("Option D")]
        public string OptionD { get; set; }

        public string Answer { get; set; }

        [DisplayName("Enter your answer")]
        [RegularExpression("[A-Da-d ]*", ErrorMessage = "Invalid Answer Input ")]
        public string AnswerInput { get; set; }
        public string Explanation { get; set; }

        public int Total { get; set; }

        public IEnumerable<Questions> ListOfQuestions { get; set; }
    }
}
