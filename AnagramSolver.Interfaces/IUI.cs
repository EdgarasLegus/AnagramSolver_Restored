using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramSolver.Interfaces
{
    public interface IUI
    {
        string GetUserInput(int minInputWordLength);
    }
}
