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
    public class CategoryCommandRepository : CommandRepositoryBase, ICategoryCommandRepository
    {
        public CategoryCommandRepository(IConfiguration configuration) : base(configuration)
        {
        }

        private const string UspCategoriesCreate = "[dbo].[uspCategoriesCreate]";
        private const string UspCategoriesDelete = "[dbo].[uspCategoriesDelete]";
        private const string UspCategoriesUpdate = "[dbo].[uspCategoriesUpdate]";

        public void Create(Category entity)
        {
            using (SqlConnection con = new SqlConnection(this.DbConnectionString))
            {
                SqlCommand cmd = new SqlCommand(UspCategoriesCreate, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", entity.Name);
                cmd.Parameters.AddWithValue("@description", entity.Description);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Delete(long id)
        {
            using (SqlConnection con = new SqlConnection(this.DbConnectionString))
            {
                SqlCommand cmd = new SqlCommand(UspCategoriesUpdate, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Update(Category entity)
        {

            using (SqlConnection con = new SqlConnection(this.DbConnectionString))
            {
                SqlCommand cmd = new SqlCommand(UspCategoriesUpdate, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", entity.Id);
                cmd.Parameters.AddWithValue("@name", entity.Name);
                cmd.Parameters.AddWithValue("@description", entity.Description);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
