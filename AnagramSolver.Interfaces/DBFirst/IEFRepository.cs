using AnagramSolver.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramSolver.Interfaces.DBFirst
{
    public interface IEFRepository
    {
        List<WordEntity> GetWords();
    }
}
