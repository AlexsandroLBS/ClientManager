using ClientManager.Domain.Commands.Contracts;

namespace ClientManager.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}