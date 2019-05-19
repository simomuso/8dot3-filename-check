using System.IO;

namespace ConsoleApp2
{
    public interface IShortNamingChecker
    {
        bool CheckNamingSupport(string drive);
    }

    public class ShortNamingChecker : IShortNamingChecker
    {
        private readonly IDrivesChecker _drivesChecker;
        private readonly IRunnerAsAdmin _runner;
        private readonly string _resultPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),"output.log");


        public ShortNamingChecker(IDrivesChecker drivesChecker, IRunnerAsAdmin runner)
        {
            _drivesChecker = drivesChecker;
            _runner = runner;
        }

        public bool CheckNamingSupport(string drive)
        {
            _runner.Run("cmd", $"/C fsutil 8dot3name query {drive}", _resultPath);
            return IsShortNamingSupported();
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
