using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuizManager.DAL.Interface;
using QuizManager.Entities;

namespace QuizManager.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/Questions")]
    public class QuestionsController : Controller
    {
        public IQuestionsQueryRepository QuestionsQueryRepository { get; }

        public QuestionsController(IQuestionsQueryRepository questionsQueryRepository)
        {
            QuestionsQueryRepository = questionsQueryRepository;
        }

        [HttpGet("ReadAllQuestions")]
        public Task<IEnumerable<Questions>> ReadAllQuestions()

        {
            var result = this.QuestionsQueryRepository.ReadAllAsync();
            return result;
        }

        [HttpGet("ReadQuestionById/{id}")]
        public Task<Questions> ReadQuestionsById(int id)
        {
            var result = this.QuestionsQueryRepository.Read(id);
            return result;
        }

        [HttpGet("ReadQuestionByCategoryId/{id}")]
        public Task<IEnumerable<Questions>> ReadQuestionsByCategoryId(int id)
        {
            var result = this.QuestionsQueryRepository.ReadQuestionsByCategoryId(id);
            return result;
        }
    }
}