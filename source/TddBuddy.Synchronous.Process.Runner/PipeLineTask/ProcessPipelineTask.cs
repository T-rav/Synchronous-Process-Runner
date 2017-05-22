using System.Diagnostics;

namespace TddBuddy.Synchronous.Process.Runner.PipeLineTask
{
    public abstract class ProcessPipeLineTask
    {
        public abstract ProcessStartInfo CommandToExecute();
    }
}