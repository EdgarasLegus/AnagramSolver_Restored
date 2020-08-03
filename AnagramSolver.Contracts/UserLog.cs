using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramSolver.Contracts
{
    public class UserLog
    {
        public int Id { get; set; }
        public string UserIp { get; set; }
        public string UserSearchWord { get; set; }
        public TimeSpan SearchTime { get; set; }
    }
}
