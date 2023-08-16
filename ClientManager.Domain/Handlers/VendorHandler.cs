using ClientManager.Domain.Commands;
using ClientManager.Domain.Commands.Contracts;
using ClientManager.Domain.Entities;
using ClientManager.Domain.Handlers.Contracts;
using ClientManager.Domain.Repositories;
using Flunt.Notifications;

namespace ClientManager.Domain.Handlers
{

      public class VendorHandler : 
        Notifiable, 
        IHandler<CreateVendorCommand>
    {   
        private readonly IClientManagerRepository _repository;

        public VendorHandler(IClientManagerRepository repository){
            _repository = repository;
        }
        
        public  ICommandResult Handle(CreateVendorCommand command)
        {
            command.Validate();
            if( command.Invalid )
                return new GenericCommandResult(false, "", command.Notifications);
            var vendor = new Vendor(command.VendorCode, command.Name, command.Email, command.CellPhone);
            _repository.CreateVendor(vendor);
            return new GenericCommandResult(true, "Fornecedor criado com sucesso", vendor);

        }

    }
}