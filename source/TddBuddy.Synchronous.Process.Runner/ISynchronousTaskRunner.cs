using TddBuddy.CleanArchitecture.Domain;
using TddBuddy.CleanArchitecture.Domain.Output;
using TddBuddy.CleanArchitecture.Domain.TOs;

namespace TddBuddy.Synchronous.Process.Runner
{
    public interface ISynchronousTaskRunner : IAction<string>
    {
        void Execute(string input, IRespondWithSuccessOrError<string, ErrorOutputTo> presenter);
    }
}
