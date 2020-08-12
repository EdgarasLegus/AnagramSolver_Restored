using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramSolver.Contracts.Entities
{
    public partial class UserLogEntity
    {
        //Id nera DBFirst
        public int Id { get; set; }
        public string UserIp { get; set; }
        public int SearchWordId { get; set; }
        public DateTime SearchTime { get; set; }

        public virtual CachedWordEntity SearchWord { get; set; }
    }
    //public class UserLogEntity
    //{
    //    public string UserIp { get; set; }
    //    public int SearchWordId { get; set; }
    //    public TimeSpan SearchTime { get; set; }

    //}
}
