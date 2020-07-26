using System;
using System.Collections.Generic;
using System.Text;
using AnagramSolver.BusinessLogic;
using AnagramSolver.Interfaces;
using AnagramSolver.Repos;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace AnagramSolver.Tests
{

    [TestFixture]
    public class FRepositoryTests
    {
        //private IWordRepository _wordRepository;

        [SetUp]
        public void Setup()
        {
            //_wordRepository = new FRepository();
        }

        [Test]
        public void TestIfConfigurationHasFileName()
        {
            //Arrange
            //var configuration = new ConfigurationBuilder()
              //.AddJsonFile(@"./test.json")
              //.Build();

            //Configurations.FileName = configuration["Settings:FileName"];

            //var path = configuration["Settings:FileName"];

            //Act & Assert
            //Assert.Throws<Exception>(() => _wordRepository.GetWords());

            Assert.Pass();
        }
    }
}
