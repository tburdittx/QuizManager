using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using QuizManager.DAL.Interface;
using QuizManager.Entities;

namespace QuizManager.DAL
{
   public class QuestionsCommandRepository:CommandRepositoryBase, IQuestionsCommandRepository
    {
        private const string UspQuestionsCreate = "[dbo].[uspQuestionsCreate]";
        private const string UspQuestionsDelete = "[dbo].[uspQuestionsDelete]";
        private const string UspQuestionsUpdate = "[dbo].[uspQuestionsUpdate]";

        public QuestionsCommandRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public void Create(Questions entity)
        {
            using (SqlConnection con = new SqlConnection(this.DbConnectionString))
            {
                SqlCommand cmd = new SqlCommand(UspQuestionsCreate, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@categoryId", entity.CategoryId);
                cmd.Parameters.AddWithValue("@question", entity.Question);
                cmd.Parameters.AddWithValue("@optionA", entity.OptionA);
                cmd.Parameters.AddWithValue("@optionB", entity.OptionB);
                cmd.Parameters.AddWithValue("@optionC", entity.OptionC);
                cmd.Parameters.AddWithValue("@optionD", entity.OptionD);
                cmd.Parameters.AddWithValue("@answer", entity.Answer);
                cmd.Parameters.AddWithValue("@explanation", entity.Explanation);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Delete(long id)
        {
            using (SqlConnection con = new SqlConnection(this.DbConnectionString))
            {
                SqlCommand cmd = new SqlCommand(UspQuestionsDelete, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Update(Questions entity)
        {
            using (SqlConnection con = new SqlConnection(this.DbConnectionString))
            {
                SqlCommand cmd = new SqlCommand(UspQuestionsUpdate, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", entity.Id);
                cmd.Parameters.AddWithValue("@categoryId", entity.CategoryId);
                cmd.Parameters.AddWithValue("@question", entity.Question);
                cmd.Parameters.AddWithValue("@optionA", entity.OptionA);
                cmd.Parameters.AddWithValue("@optionB", entity.OptionB);
                cmd.Parameters.AddWithValue("@optionC", entity.OptionC);
                cmd.Parameters.AddWithValue("@optionD", entity.OptionD);
                cmd.Parameters.AddWithValue("@answer", entity.Answer);
                cmd.Parameters.AddWithValue("@explanation", entity.Explanation);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
