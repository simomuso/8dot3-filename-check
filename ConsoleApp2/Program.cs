using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] Args)
        {
            var drive = Args[0];

            var drivesChecker = new DrivesChecker();
            var runnerAsAdmin = new RunnerAsAdmin();
            var shortNamingChecker = new ShortNamingChecker(drivesChecker, runnerAsAdmin);

            if (drivesChecker.IsDriveInstalled(drive))
            {
                Console.WriteLine(shortNamingChecker.CheckNamingSupport(drive)
                    ? $"8.3 file naming support on ({drive}) --> YES"
                    : $"8.3 file naming support on ({drive}) --> NO");
            }
            else
            {
                Console.WriteLine($"Drive ({drive}) not installed or valid");
            }
            Console.ReadKey();
        }
    }
}
