using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizManager.DAL.Interface
{
    public interface ICommandRepositoryBase<T> where T:new()
    {
        void Create(T entity);
        void Delete(long id);
        void Update(T entity);
    }
}
