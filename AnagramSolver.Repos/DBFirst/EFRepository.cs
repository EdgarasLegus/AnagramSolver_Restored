using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnagramSolver.Contracts.Entities;
using AnagramSolver.EF.DatabaseFirst;
using AnagramSolver.Interfaces.DBFirst;

namespace AnagramSolver.Repos
{
    public class EFRepository : IEFRepository
    {
        private readonly AnagramSolverDBFirstContext _context;

        public EFRepository(AnagramSolverDBFirstContext context)
        {
            _context = context;
        }

        public List<WordEntity> GetWords()
        {
            var wordModelList = _context.Word.ToList();
            return wordModelList;
        }
    }
}
