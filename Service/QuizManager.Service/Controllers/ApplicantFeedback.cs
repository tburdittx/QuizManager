using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuizManager.DAL.Interface;
using QuizManager.Entities;

namespace QuizManager.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/ApplicantFeedback")]
    public class ApplicantFeedbackController : Controller
    {
        public IApplicantFeedbackQueryRepository ApplicantFeedbackQueryRepository { get; }
        public IApplicantFeedbackCommandRepository ApplicantFeedbackCommandRepository { get; }

        public ApplicantFeedbackController(IApplicantFeedbackQueryRepository applicantFeedbackQueryRepository,
            IApplicantFeedbackCommandRepository applicantFeedbackCommandRepository)
        {
            ApplicantFeedbackQueryRepository = applicantFeedbackQueryRepository;
            ApplicantFeedbackCommandRepository = applicantFeedbackCommandRepository;
        }

        [HttpGet("ReadAllApplicantFeedback")]
        public Task<IEnumerable<ApplicantFeedback>> ReadAllQuestions()
        {
            var result = ApplicantFeedbackQueryRepository.ReadAllAsync();
            return result;
        }

        [HttpGet("ReadApplicantFeedbackById/{id}")]
        public Task<ApplicantFeedback> ReadQuestionsById(int id)
        {
            var result = this.ApplicantFeedbackQueryRepository.Read(id);
            return result;
        }

        [HttpPost("CreateApplicantFeedback")]
        public void CreateApplicantFeedback([FromBody] ApplicantFeedback entity)
        {
            ApplicantFeedbackCommandRepository.Create(entity);
        }

        [HttpPost("EditApplicantFeedback/{id}")]
        public void EditApplicantFeedback([FromBody] ApplicantFeedback entity)
        {
            ApplicantFeedbackCommandRepository.Update(entity);
        }

        [HttpPost("DeleteApplicantFeedback/{id}")]
        public void DeleteApplicantFeedback(int id)
        {
            ApplicantFeedbackCommandRepository.Delete(id);
        }
    }
}
