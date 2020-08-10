using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramSolver.Contracts.Entities
{
    public class WordEntity
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public string Category { get; set; }
    }
}
