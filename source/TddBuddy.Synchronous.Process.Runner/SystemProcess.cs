using System.Diagnostics;
using System.IO;
using System.Text;
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
            get => _process.StartInfo;
            set => _process.StartInfo = value;
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

        public void WriteToStdInput(string input)
        {
            if (input == null)
            {
                return;
            }

            using (var inputStreamWriter = new StreamWriter(_process.StandardInput.BaseStream, new UTF8Encoding(false)))
            {
                inputStreamWriter.Write(input);
                inputStreamWriter.Close();
            }
        }
    }
}