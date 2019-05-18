using System;
using System.IO;

namespace ConsoleApp2
{
    public interface IShortNamingChecker
    {
        void CheckNamingSupport(string drive);
    }

    public class ShortNamingChecker : IShortNamingChecker
    {
        private readonly IDrivesChecker _drivesChecker;
        private readonly IRunnerAsAdmin _runner;

        private readonly string _resultPath =
            Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);

        public ShortNamingChecker(IDrivesChecker drivesChecker, IRunnerAsAdmin runner)
        {
            _drivesChecker = drivesChecker;
            _runner = runner;
        }

        public void CheckNamingSupport(string drive)
        {
            if (_drivesChecker.IsDriveInstalled(drive))
            {
                _runner.Run("cmd", $"/C fsutil 8dot3name query {drive}", _resultPath);

                Console.WriteLine(IsShortNamingSupported()
                    ? "ShortNaming supportato."
                    : "ShortNaming non supportato.");

                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Errore: drive specificato non esistente o non supportato");
            }
        }

        private bool IsShortNamingSupported()
        {
            var reader = new StreamReader(_resultPath);

            var firstLine = reader.ReadLine();
            var secondLine = reader.ReadLine();

            return firstLine.Contains("0") && secondLine.Contains("2");
        }
    }
}
