using System;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QuizManager.DAL.Interface;
using QuizManager.Entities;
using FluentAssertions;
using System.Collections.Generic;

namespace QuizManager.DAL.Tests
{
    [TestClass]
    public class QuestionsQueryRepositoryTests
    {
        // private readonly string connectionString = "connectionString";
        string connectionString = "Server=ICAEW-PC\\SQLSERVER2016;Database=QuizManager;Trusted_Connection=True;";
        private IQuestionsQueryRepository RepositoryUnderTest { get; set; }

        private Mock<IConfiguration> Configuration { get; set; }

        [TestInitialize]
        public void SetUp()
        {
          
            this.Configuration = new Mock<IConfiguration>();
             this.Configuration.Setup(x => x.GetSection("ConnectionStrings")["QuizManager"]).Returns(this.connectionString);
            
            this.CreateRepositoryUnderTest();
           // this.Configuration.Reset("");
        }

        [TestMethod]
        public void ReadQuestionById()
        {
            //Arrange
            long id = 10L;
            object sprocParam = new { id };

            //Act
            Questions expectedResult = new Questions
            {
                Id = 10
            };

            //Assert
            Assert.AreEqual(expectedResult.Id, id);            
        }

        [TestMethod]
        public void ReadQuestionsByCategoryId()
        {
            //Arrange  
            var controller = RepositoryUnderTest;
            long Id = 1;

            var list = new List<Questions>
            {
                new Questions(),
                new Questions()
            };

//Act  
            var data = controller.ReadQuestionsByCategoryId(Id);

            //Assert  

            data.Should().NotBeNull();
        }

        [TestMethod]
        public void ReadAllQuestions()
        {
            //Arrange
            var repo = RepositoryUnderTest;

            var list = new List<Questions>
            {
                new Questions(),
                new Questions()
            };

            //Act  
            var data = repo.ReadAllAsync();

            //Assert  

            data.Should().NotBeNull();
        }


        private void CreateRepositoryUnderTest()
        {
            this.RepositoryUnderTest = new QuestionsQueryRepository(
                Configuration.Object
                );
        }
    }
}
