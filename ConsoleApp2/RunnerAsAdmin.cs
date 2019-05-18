using System.Diagnostics;

namespace ConsoleApp2
{
    public interface IRunnerAsAdmin
    {
        void Run(string cmd, string args, string resultPath);
    }

    public class RunnerAsAdmin : IRunnerAsAdmin
    {
        public void Run(string cmd, string args, string resultPath)
        {
            var process = new Process();
            var startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = cmd,
                Arguments = $"{args} > {resultPath}",
                Verb = "runas",
            };

            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }
    }
}
