using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramSolver.Interfaces
{
    public interface IWordRepository
    {
        Dictionary<string, string> GetWords();
    }
}
