using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using QuizManager.DAL.Interface;
using QuizManager.Entities;

namespace QuizManager.DAL
{
    public class ApplicantFeedbackQueryRepository : QueryRepositoryBase, IApplicantFeedbackQueryRepository

    {
        private const string uspApplicantFeedbackRead = "[dbo].[uspApplicantFeedbackReadById]";
        private const string uspApplicantFeedbackReadAll = "[dbo].[uspApplicantFeedbackReadAll]";

        public ApplicantFeedbackQueryRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<ApplicantFeedback> Read(long id)
        {
            ApplicantFeedback result = new ApplicantFeedback();

            using (var connection = new SqlConnection(DbConnectionString))
            {
                result = connection.Query<ApplicantFeedback>(uspApplicantFeedbackRead, new { Id = id },
                commandType: CommandType.StoredProcedure).First();
            }
            return result;
        }

        public async Task<IEnumerable<ApplicantFeedback>> ReadAllAsync()
        {
            IEnumerable<ApplicantFeedback> result;

            using (var connection = new SqlConnection(DbConnectionString))
            {
                result = await connection.QueryAsync<ApplicantFeedback>(uspApplicantFeedbackReadAll);
            }
            return result;
        }
    }
}
