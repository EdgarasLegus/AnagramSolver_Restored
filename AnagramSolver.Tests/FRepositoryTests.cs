using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AnagramSolver.BusinessLogic;
using AnagramSolver.Contracts;
using AnagramSolver.Interfaces;
using AnagramSolver.Repos;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace AnagramSolver.Tests
{

    [TestFixture]
    public class FRepositoryTests
    {
        private IWordRepository _wordRepository;

        [SetUp]
        public void Setup()
        {
            _wordRepository = new FRepository();
        }

        [Test]
        public void TestIfConfigurationHasFileName()
        {
            //Arrange
            var configuration = new ConfigurationBuilder()
              .AddJsonFile(@"./appsettings.json")
              .Build();

            Contracts.ConfigurationConstants.FileName = configuration["Settings:FileName"];

            //var path = configuration["Settings:FileName"];

            //Act & Assert
            Assert.Throws<Exception>(() => _wordRepository.GetWords());

            //Assert.Pass();
        }

        [Test]
        public void TestIfAllWordsArePickedUp()
        {
            //Arrange
            Contracts.ConfigurationConstants.FileName = "test.txt";
            int countme;
            using (StreamReader reader = new StreamReader(ConfigurationConstants.FileName))
            {
                string line;
                int counter = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    string word = line.Split('\t').ToList().First();
                    counter++;
                }
                countme = counter;
            }

            // Act
            Dictionary<string, string> firstColumn = _wordRepository.GetWords();

            //Assert (starting from 0)
            Assert.AreEqual(firstColumn.Count+1, countme);

        }
    }
}
