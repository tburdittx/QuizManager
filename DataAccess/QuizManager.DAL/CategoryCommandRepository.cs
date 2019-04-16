using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using QuizManager.DAL.Interface;
using QuizManager.Entities;

namespace QuizManager.DAL
{
    public class CategoryCommandRepository : CommandRepositoryBase, ICategoryCommandRepository
    {
        public CategoryCommandRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public void Create(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
