using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramSolver.Contracts
{
    public class Settings
    {
        public static int MaxNumberOfAnagrams { get; set; }
        public static int MinInputWordLength { get; set; }
        public static int MinNumberOfAnagrams { get; set; }
        public static string FileName { get; set; }

    }
}
