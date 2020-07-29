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
        public void TestIfFileExists()
        {
            //Arrange
            ConfigurationConstants.FileName = "test.txt";
            //Act & Assert
            FileAssert.Exists(ConfigurationConstants.FileName);
        }

        [Test]
        public void TestIfAllWordsArePickedUpFromFile()
        {
            //Arrange
            Contracts.ConfigurationConstants.FileName = "test.txt";
            int actualCountOfWords;
            using (StreamReader reader = new StreamReader(ConfigurationConstants.FileName))
            {
                string line;
                int counter = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    string wordFromFirstColumn = line.Split('\t').ToList().First();
                    counter++;
                }
                actualCountOfWords = counter;
            }
            // Act
            Dictionary<string, string> firstColumn = _wordRepository.GetWords();

            //Assert (starting from 0)
            Assert.AreEqual(firstColumn.Count+1, actualCountOfWords);

        }
    }
}
