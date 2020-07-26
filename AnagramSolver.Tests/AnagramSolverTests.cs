using AnagramSolver.BusinessLogic;
using AnagramSolver.Interfaces;
using AnagramSolver.Repos;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using NSubstitute;
using System.ComponentModel.DataAnnotations;

namespace AnagramSolver.Tests
{
    [TestFixture]
    public class AnagramSolverTests
    {
        private IAnagramSolver _anagramSolver;
        //private IConfigurationRoot _configuration;
       

        [SetUp]
        public void Setup()
        {
            _anagramSolver = new BusinessLogic.AnagramSolver()
            {
                FRepository = new FRepository()
                {
                    _configuration = new ConfigurationBuilder().AddJsonFile(@"./test.json").Build()
                }
            };

            //_configuration = new ConfigurationBuilder().AddJsonFile(@"./test.json").Build();
            //Configurations.FileName = _configuration["Settings:FileName"];
        }

        [Test]
        public void TestIfInputIsSortedCorrectly()
        {
            //Arrange
            var inputWord = "absorbavimas";
            var expectedOutput = "aaabbimorssv";

            //Act
            var output = _anagramSolver.SortByAlphabet(inputWord);
            var ifContains = output.Contains(expectedOutput);

            //Assert
            Assert.IsTrue(ifContains);

            //Assert.Pass();
        }
    }
}