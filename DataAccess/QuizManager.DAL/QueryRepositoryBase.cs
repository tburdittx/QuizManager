using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace QuizManager.DAL
{
    public class QueryRepositoryBase
    {
        private readonly IConfiguration configuration;

        private const string DbName = "QuizManager";

        public QueryRepositoryBase(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IConfiguration Configuration => this.configuration;

        public string DbConnectionString => this.Configuration.GetConnectionString(DbName);
    }
}
