using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramSolver.Contracts.Entities
{
    public class UserLogEntity
    {
        public string UserIp { get; set; }
        public int SearchWordId { get; set; }
        public TimeSpan SearchTime { get; set; }

    }
}
