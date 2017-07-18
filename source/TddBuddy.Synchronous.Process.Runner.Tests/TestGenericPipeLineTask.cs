using TddBuddy.Synchronous.Process.Runner.PipeLineTask;

namespace TddBuddy.Synchronous.Process.Runner.Tests
{
    public class TestGenericPipeLineTask : NodePipeLineTask
    {
        public TestGenericPipeLineTask(string applicationPath, string arguments) : base(applicationPath, arguments)
        {
        }
    }
}