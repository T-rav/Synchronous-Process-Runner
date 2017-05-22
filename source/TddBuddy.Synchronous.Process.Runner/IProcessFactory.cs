using System.Diagnostics;

namespace TddBuddy.Synchronous.Process.Runner
{
    public interface IProcessFactory
    {
        IProcess CreateProcess(ProcessStartInfo startInfo);
    }
}