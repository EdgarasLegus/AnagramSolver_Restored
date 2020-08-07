using AnagramSolver.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramSolver.Interfaces
{
    public interface IDatabaseLogic
    {
        List<WordModel> SearchWords(string searchInput);
    }
}
