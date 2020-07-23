using System;
using System.Collections.Generic;

namespace AnagramSolver.Interfaces
{
    public interface IAnagramSolver
    {
        IList<string> GetAnagrams(string myWords);
    }
}
