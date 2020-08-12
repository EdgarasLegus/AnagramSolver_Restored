using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnagramSolver.Contracts.Entities;
using AnagramSolver.EF.DatabaseFirst;
using AnagramSolver.Interfaces.DBFirst;
using AnagramSolver.EF.CodeFirst;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AnagramSolver.Repos
{
    public class EFRepository : IEFRepository
    {
        //private readonly AnagramSolverDBFirstContext _context;
        private readonly AnagramSolverCodeFirstContext _context;

        //public EFRepository(AnagramSolverDBFirstContext context)
        //{
        //    _context = context;
        //}

        public EFRepository(AnagramSolverCodeFirstContext context)
        {
            _context = context;
        }

        public List<WordEntity> GetWords()
        {
            var wordModelList = _context.Word.ToList();
            return wordModelList;
        }

        // CODE FIRST
        public List<WordEntity> GetWordEntityFromFile()
        {
            var configuration = new ConfigurationBuilder()
               .AddJsonFile(@"./appsettings.json")
               .Build();

            var path = configuration["Settings:FileName"];

            if (!File.Exists(path))
            {
                throw new Exception($"Data file {path} does not exist!");
            }

            var wordModelList = new Dictionary<string, string>();

            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string word = line.Split('\t').First();
                    string PartOfSpeech = line.Split('\t').ElementAt(1);
                    var wordModel = new WordEntity()
                    {
                        Word1 = word,
                        Category = PartOfSpeech
                    };
                    if (!wordModelList.ContainsKey(word))
                    {
                        wordModelList.Add(wordModel.Word1, wordModel.Category);
                    }
                }
            }
            var returnList = wordModelList.Select(pair => new WordEntity()
            {
                Word1 = pair.Key,
                Category = pair.Value
            }).ToList();
            return returnList;

        }

        // CODE FIRST
        public void InsertWordTableData(List<WordEntity> fileColumns)
        {
            var enity = new WordEntity();
            foreach (var item in fileColumns)
            {

                var wordEntity = new WordEntity
                {
                    Id = item.Id,
                    Word1 = item.Word1,
                    Category = item.Category
                };
               _context.Word.Add(wordEntity);
               _context.SaveChanges();
            }
            //_context.Word.Add(wordEntity);
            //_context.SaveChanges();
        }

        //public void InsertWordTableData(List<WordEntity> fileColumns)
        //{
        //    var wordEntity = new List<WordEntity>();
        //    var wordEntityId = fileColumns.Select(x => x.Id).ToList();
        //    var wordEntityWord = fileColumns.Select(x => x.Word1).ToList();
        //    var wordEntityCategory = fileColumns.Select(x => x.Category).ToList();
        //    wordEntity.ForEach(x => {x.Id = wordEntityId)

        //    var entity = new List<WordEntity>();
        //    foreach (var item in fileColumns)
        //    {
        //        var wordEntity = new WordEntity
        //        {
        //            Id = item.Id,
        //            Word1 = item.Word1,
        //            Category = item.Category
        //        };
        //        _context.Word.Add(wordEntity);
        //        //_context.SaveChanges();
        //    }
        //    _context.Word.Add(entity);
        //    _context.SaveChanges();
        //}


    }
}
