using ClientManager.Domain.Commands.Contracts;

namespace ClientManager.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}