using System;
using System.Collections.Generic;
using System.Text;
using AnagramSolver.EF.DatabaseFirst;
using AnagramSolver.Contracts.Entities;
using System.Linq;
using AnagramSolver.Contracts;
using AnagramSolver.Interfaces.DBFirst;
using System.Runtime.CompilerServices;
using AnagramSolver.EF.CodeFirst;
using System.Net;
using System.Net.Sockets;

namespace AnagramSolver.BusinessLogic
{
    public class EFLogic : IEFLogic
    {
        public string GetIP()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("IP is not recognised!");
        }
    }
}
