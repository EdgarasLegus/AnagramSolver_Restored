using AnagramSolver.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramSolver.Interfaces.DBFirst
{
    public interface IEFRepository
    {
        List<WordEntity> GetWords();
        //CODE FIRST METHOD
        List<WordEntity> GetWordEntityFromFile();
        //CODE FIRST METHOD
        void InsertWordTableData(List<WordEntity> fileColumns);
    }
}
