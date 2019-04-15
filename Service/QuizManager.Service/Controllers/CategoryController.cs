using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuizManager.DAL.Interface;
using QuizManager.Entities;

namespace QuizManager.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/Category")]
    public class CategoryController : Controller
    {
        public ICategoryQueryRepository CategoryQueryRepository { get; }

        public CategoryController(ICategoryQueryRepository categoryQueryRepository)
        {
            CategoryQueryRepository = categoryQueryRepository;
        }

        [HttpGet("ReadAllCategories")]
        public Task<IEnumerable<Category>> ReadAllQuestions()

        {
            var result = CategoryQueryRepository.ReadAllAsync();
            return result;
        }
    }
}