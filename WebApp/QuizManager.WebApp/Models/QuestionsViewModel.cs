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
        public long Id { get; set; }
        public string Question { get; set; }

        public int CategoryId { get; set; }

        [DisplayName("Category Name")]
        public string CategoryName { get; set; }

        [DisplayName("Option A")]
        public string OptionA { get; set; }

        [DisplayName("Option B")]
        public string OptionB { get; set; }

        [DisplayName("Option C")]
        public string OptionC { get; set; }

        [DisplayName("Option D")]
        public string OptionD { get; set; }

        public string Answer { get; set; }

        [DisplayName("Your answer")]
        [RegularExpression("[A-Da-d ]*", ErrorMessage = "Invalid Answer Input ")]
        public string AnswerInput { get; set; }
        public string Explanation { get; set; }

        public string Correct { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        
        public string ModifiedBy { get; set; }
        
        public DateTime ModifiedDate { get; set; }

        public IEnumerable<QuestionsViewModel> ListOfQuestions { get; set; }
    }
}
