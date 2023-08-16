
using ClientManager.Domain.Commands;
using ClientManager.Domain.Commands.Contracts;
using ClientManager.Domain.Entities;
using ClientManager.Domain.Handlers.Contracts;
using ClientManager.Domain.Repositories;
using Flunt.Notifications;

namespace ClientManager.Domain.Handlers
{

      public class ClientHandler : 
        Notifiable, 
        IHandler<CreateClientCommand>
    {   
        private readonly IClientManagerRepository _repository;

        public ClientHandler(IClientManagerRepository repository){
            _repository = repository;
        }
        
        public  ICommandResult Handle(CreateClientCommand command)
        {
            command.Validate();
            if( command.Invalid )
                return new GenericCommandResult(false, "", command.Notifications);

            var client = new Client(command.ClientCode, command.Name, command.DocumentNo, command.Address);
            _repository.CreateClient(client);
            return new GenericCommandResult(true, "Cliente criado com sucesso", client);
        }

    }
}