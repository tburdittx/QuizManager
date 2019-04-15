using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizManager.Entities;

namespace QuizManager.DAL.Interface
{
    public interface IQuestionsQueryRepository:IQueryRepositoryBase<Questions>
    {
        Task<IEnumerable<Questions>> ReadQuestionsByCategoryId(long id);
    }
}
