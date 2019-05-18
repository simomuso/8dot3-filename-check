using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] Args)
        {
            var drive = Args[0].ToLower();
            var shortNamingChecker = new ShortNamingChecker(new DrivesChecker(), new RunnerAsAdmin());

            shortNamingChecker.CheckNamingSupport(drive);
        }
    }
}
