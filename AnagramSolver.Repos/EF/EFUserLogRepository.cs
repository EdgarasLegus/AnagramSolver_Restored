using AnagramSolver.Contracts.Entities;
using AnagramSolver.EF.CodeFirst;
using AnagramSolver.EF.DatabaseFirst;
using AnagramSolver.Interfaces.DBFirst;
using System;
using System.Collections.Generic;
using System.Text;
using AnagramSolver.Interfaces.EF;
using System.Linq;
using AnagramSolver.Contracts;

namespace AnagramSolver.Repos.EF
{
    public class EFUserLogRepository : IEFUserLogRepo
    {
        //private readonly AnagramSolverDBFirstContext _context;
        private readonly AnagramSolverCodeFirstContext _context;
        private readonly IEFLogic _efLogic;
        //public EFLogic(AnagramSolverDBFirstContext context, IEFLogic efLogic)
        //{
        //    _context = context;
        //    _efLogic = efLogic;
        //}

        public EFUserLogRepository(AnagramSolverCodeFirstContext context, IEFLogic efLogic)
        {
            _context = context;
            _efLogic = efLogic;
        }

        public void InsertUserLog(string searchInput)
        {
            var ip = _efLogic.GetIP();
            var userLogEntity = new UserLogEntity
            {
                UserIp = ip,
                SearchWord = searchInput,
                SearchTime = DateTime.Now
            };
            _context.UserLog.Add(userLogEntity);
            _context.SaveChanges();
        }

        public int CheckUserLogIp()
        {
            var ip = _efLogic.GetIP();
            var check = _context.UserLog.Where(x => x.UserIp == ip).Select(x => x.UserIp).Count();
            return check;
        }
    }
}
