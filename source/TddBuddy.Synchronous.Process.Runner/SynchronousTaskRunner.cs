using TddBuddy.CleanArchitecture.Domain.Output;
using TddBuddy.CleanArchitecture.Domain.TOs;
using TddBuddy.Synchronous.Process.Runner.PipeLineTask;

namespace TddBuddy.Synchronous.Process.Runner
{
    public class SynchronousTaskRunner : ISynchronousTaskRunner
    {
        private readonly IProcessFactory _processFactory;
        private readonly ProcessPipeLineTask _processPipeLineTask;

        public SynchronousTaskRunner(ProcessPipeLineTask processPipeLineTask, IProcessFactory processFactory)
        {
            _processPipeLineTask = processPipeLineTask;
            _processFactory = processFactory;
        }

        public void Execute(IRespondWithSuccessOrError<string, ErrorOutputTo> presenter)
        {
            Execute(null, presenter);
        }

        public void Execute(string input, IRespondWithSuccessOrError<string, ErrorOutputTo> presenter)
        {
            var processStartInfo = _processPipeLineTask.CommandToExecute();

            using (var process = _processFactory.CreateProcess(processStartInfo))
            {
                process.Start();

                var outputTask = process.ReadStdOutToEndAsync();
                var errorTask = process.ReadStdErrToEndAsync();

                process.WriteToStdInput(input);

                process.WaitForExit();

                var error = errorTask.Result;
                if (!string.IsNullOrWhiteSpace(error))
                {
                    var errorOutputTo = new ErrorOutputTo();
                    errorOutputTo.AddError(error);
                    presenter.Respond(errorOutputTo);
                    return;
                }
                presenter.Respond(outputTask.Result);
            }
        }
    }
}