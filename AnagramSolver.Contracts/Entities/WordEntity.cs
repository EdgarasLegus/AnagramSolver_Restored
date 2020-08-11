using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramSolver.Contracts.Entities
{
    public partial class WordEntity
    {
        public WordEntity()
        {
            CachedWord = new HashSet<CachedWordEntity>();
        }

        public int Id { get; set; }
        public string Word1 { get; set; }
        public string Category { get; set; }

        public virtual ICollection<CachedWordEntity> CachedWord { get; set; }
    }
    //public class WordEntity
    //{
    //    public int Id { get; set; }
    //    public string Word { get; set; }
    //    public string Category { get; set; }
    //}
}
