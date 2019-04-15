using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizManager.DAL.Interface;
using QuizManager.Entities;
using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace QuizManager.DAL
{
    public class QuestionsQueryRepository : QueryRepositoryBase, IQuestionsQueryRepository
    {

        private const string uspQuestionsReadAll = "[dbo].[uspQuestionsReadAll]";
        private const string uspQuestionsRead = "[dbo].[uspQuestionsReadById]";
        private const string uspQuestionsReadByCategoryId = "[dbo].[uspQuestionsReadByCategoryId]";

        public QuestionsQueryRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<Questions> Read(long id)
        {
            Questions result = new Questions();

            using (var connection = new SqlConnection(DbConnectionString))
            {
                result = connection.Query<Questions>(uspQuestionsRead, new { Id = id },
                commandType: CommandType.StoredProcedure).First();
            }
            return result;
        }

        public async Task<IEnumerable<Questions>> ReadAllAsync()
        {
            IEnumerable<Questions> result;

            using (var connection = new SqlConnection(DbConnectionString))
            {
                result = await connection.QueryAsync<Questions>(uspQuestionsReadAll);
            }
            return result;
        }

        public async Task<IEnumerable<Questions>> ReadQuestionsByCategoryId(long id)
        {
            IEnumerable<Questions> result;

            using (var connection = new SqlConnection(DbConnectionString))
            {
                result = await connection.QueryAsync<Questions>(uspQuestionsReadByCategoryId, new { categoryId = id },
                commandType: CommandType.StoredProcedure);
            }
            return result;
        }
    }
}
