using ClientManager.Domain.Commands;
using ClientManager.Domain.Commands.Contracts;
using ClientManager.Domain.Entities;
using ClientManager.Domain.Handlers.Contracts;
using ClientManager.Domain.Repositories;
using Flunt.Notifications;

namespace ClientManager.Domain.Handlers
{
    public class OrderHandler : 
        Notifiable, 
        IHandler<CreateOrderCommand>,
        IHandler<MarkOrderAsDoneCommand>,
        IHandler<MarkOrderAsCancelledCommand>

    {   
        private readonly IClientManagerRepository _repository;

        public OrderHandler(IClientManagerRepository repository){
            _repository = repository;
        }

        public ICommandResult Handle(CreateOrderCommand command)
        {
            command.Validate();
            if( command.Invalid )
                return new GenericCommandResult(false, "", command.Notifications);
            var order = new Order(command.OrderNumber, command.ClientCode, command.VendorCode, command.CreatedAt);
            _repository.CreateOrder(order);
            return new GenericCommandResult(true, "Ordem de pedido criada com sucesso!", order);
        }

        public ICommandResult Handle(MarkOrderAsDoneCommand command)
        {
            var order = _repository.GetOrderByOrderNo(command.OrderNumber);
            order.MarkAsDone();
            _repository.UpdateOrder(order);

            return new GenericCommandResult(true, "Ordem finalizada com sucesso!", order);
        }

        public ICommandResult Handle(MarkOrderAsCancelledCommand command)
        {
            var order = _repository.GetOrderByOrderNo(command.OrderNumber);
            order.MarkAsCancelled();
            _repository.UpdateOrder(order);

             return new GenericCommandResult(true, "Ordem finalizada com sucesso!", order);
        }
    }
}