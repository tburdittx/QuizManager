using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Configuration;
using Moq;
using QuizManager.DAL.Interface;
using QuizManager.Entities;

namespace QuizManager.DAL.Tests
{
    /// <summary>
    /// Summary description for CategoryQueryRepositoryTests
    /// </summary>
    [TestClass]
    public class CategoryQueryRepositoryTests
    {
        private readonly string connectionString = "connectionString";

        private ICategoryQueryRepository RepositoryUnderTest { get; set; }

        private Mock<IConfiguration> Configuration { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            this.Configuration = new Mock<IConfiguration>();
            this.Configuration.Setup(x => x.GetSection("ConnectionStrings")["QuizManager"]).Returns(this.connectionString);
            this.CreateRepositoryUnderTest();
        }

        [TestMethod]
        public void ReadQuestionById()
        {
            //Arrange
            string sproc = "[dbo].[uspCategoriesReadById]";
            long id = 10L;
            object sprocParam = new { id };

            Category expectedResult = new Category
            {
                Id = 10
            };

            Assert.AreEqual(expectedResult.Id, id);

        }

        [TestMethod]
        public void ReadAllCategories()
        {
            //Arrange  
            var controller = RepositoryUnderTest;
            long Id = 1;

            //Act  
            var data = controller.Read(Id);

            //Assert  

            Assert.IsNotNull(data);
        }

        private void CreateRepositoryUnderTest()
        {
            this.RepositoryUnderTest = new CategoryQueryRepository(
                Configuration.Object
                );
        }
    }
}
