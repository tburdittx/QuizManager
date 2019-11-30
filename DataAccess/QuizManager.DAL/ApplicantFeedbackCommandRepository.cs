using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using QuizManager.DAL.Interface;
using QuizManager.Entities;


namespace QuizManager.DAL
{
    public class ApplicantFeedbackCommandRepository : CommandRepositoryBase, IApplicantFeedbackCommandRepository
    {
        private const string UspApplicantFeedbackCreate = "[dbo].[uspAllpicantFeedbackCreate]";
        private const string UspApplicantFeedbackDelete = "[dbo].[uspAllpicantFeedbackDelete]";
        private const string UspApplicantFeedbackUpdate = "[dbo].[uspAllpicantFeedbackUpdate]";

        public ApplicantFeedbackCommandRepository(IConfiguration configuraion) : base(configuraion)
        {

        }

        public void Create(ApplicantFeedback entity)
        {
            using (SqlConnection con = new SqlConnection(DbConnectionString))
            {
                SqlCommand cmd = new SqlCommand(UspApplicantFeedbackCreate, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", entity.Id);
                cmd.Parameters.AddWithValue("@UserId", entity.UserId);
                cmd.Parameters.AddWithValue("@TopicId", entity.TopicId);
                cmd.Parameters.AddWithValue("@QuestionId", entity.QuestionId);
                cmd.Parameters.AddWithValue("@Feedback", entity.Feedback);
                cmd.Parameters.AddWithValue("@CreatedDate", entity.CreatedDate);
                cmd.Parameters.AddWithValue("@CreatedBy", entity.CreatedBy);
                cmd.Parameters.AddWithValue("@ModifiedDate", entity.ModifiedDate);
                cmd.Parameters.AddWithValue("@ModifiedBy", entity.ModifiedBy);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(ApplicantFeedback entity)
        {
            throw new NotImplementedException();
        }
    }
}
