using System.Diagnostics;
using System.Threading.Tasks;

namespace TddBuddy.Synchronous.Process.Runner
{
    public class SystemProcess : IProcess
    {
        private readonly System.Diagnostics.Process _process;

        public SystemProcess()
        {
            _process = new System.Diagnostics.Process();
        }

        public void Dispose()
        {
            _process.Dispose();
        }

        public ProcessStartInfo StartInfo
        {
            get { return _process.StartInfo; }
            set { _process.StartInfo = value; }
        }

        public void Start()
        {
            _process.Start();
        }

        public void WaitForExit()
        {
            _process.WaitForExit();
        }

        public Task<string> ReadStdOutToEndAsync()
        {
            return _process.StandardOutput.ReadToEndAsync();
        }

        public Task<string> ReadStdErrToEndAsync()
        {
            return _process.StandardError.ReadToEndAsync();
        }
    }
}