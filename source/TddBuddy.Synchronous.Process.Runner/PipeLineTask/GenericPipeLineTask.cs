using System;
using System.Diagnostics;
using System.Text;

namespace TddBuddy.Synchronous.Process.Runner.PipeLineTask
{
    public abstract class GenericPipeLineTask : ProcessPipeLineTask
    {
        private readonly string _arguments;
        private readonly string _applicationPath;

        protected GenericPipeLineTask(string applicationPath, string arguments)
        {
            if (string.IsNullOrWhiteSpace(applicationPath)) throw new ArgumentException(nameof(applicationPath));
            _applicationPath = applicationPath;
            _arguments = arguments;
        }

        public override ProcessStartInfo CommandToExecute()
        {
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C \"{_applicationPath}\" {_arguments}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                StandardErrorEncoding = Encoding.UTF8,
                StandardOutputEncoding = Encoding.UTF8
            };
            return processStartInfo;
        }
    }
}
