using System;
using System.Collections.Generic;
using System.Text;
using AnagramSolver.Contracts;

namespace AnagramSolver.Interfaces
{
    public interface IDBRepository
    {
        void FillDatabaseFromFile(WordModel wordModel);
        bool checkIfTableIsEmpty();
    }
}
