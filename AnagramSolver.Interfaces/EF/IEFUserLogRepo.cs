using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramSolver.Interfaces.EF
{
    public interface IEFUserLogRepo
    {
        void InsertUserLog(string searchInput, string ip);
        int CheckUserLogIp(string ip);
    }
}
