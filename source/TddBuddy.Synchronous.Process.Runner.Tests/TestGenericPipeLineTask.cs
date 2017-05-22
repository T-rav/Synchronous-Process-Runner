using TddBuddy.Synchronous.Process.Runner.PipeLineTask;

namespace TddBuddy.Synchronous.Process.Runner.Tests
{
    public class TestNodePipeLineTask : NodePipeLineTask
    {
        public TestNodePipeLineTask(string applicationPath, string arguments) : base(applicationPath, arguments)
        {
        }
    }
}