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
        public ICategoryCommandRepository CategoryCommandRepository { get; }

        public CategoryController(ICategoryQueryRepository categoryQueryRepository,
            ICategoryCommandRepository categoryCommandRepository)
        {
            CategoryQueryRepository = categoryQueryRepository;
            CategoryCommandRepository = categoryCommandRepository;
        }

        [HttpGet("ReadAllCategories")]
        public Task<IEnumerable<Category>> ReadAllQuestions()
        {
            var result = CategoryQueryRepository.ReadAllAsync();
            return result;
        }

        [HttpGet("ReadCategoryById/{id}")]
        public Task<Category> ReadQuestionsById(int id)
        {
            var result = this.CategoryQueryRepository.Read(id);
            return result;
        }

        [HttpPost("CreateCategory")]
        public void CreateCategory([FromBody] Category entity)
        {
            CategoryCommandRepository.Create(entity);
        }

        [HttpPost("EditCategory/{id}")]
        public void EditCategory([FromBody] Category entity)
        {
            CategoryCommandRepository.Update(entity);
        }

        [HttpPost("DeleteCategory/{id}")]
        public void DeleteCategory(int id)
        {
            CategoryCommandRepository.Delete(id);
        }

        [HttpPost("DeleteQuestionCategoryById/{id}")]
        public void DeleteQuestionsByCategoryById(int id)
        {
            CategoryCommandRepository.DeleteQuestionsByCategoryById(id);
        }

    }
}