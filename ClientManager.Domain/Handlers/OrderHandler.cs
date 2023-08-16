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

        public async Task<ICommandResult> Handle(CreateOrderCommand command)
        {
            command.Validate();
            if( command.Invalid )
                return new GenericCommandResult(false, "", command.Notifications);
            var order = new Order(command.OrderNumber, command.ClientCode, command.VendorCode, command.CreatedAt);
            await _repository.CreateOrder(order);
            return new GenericCommandResult(true, "Ordem de pedido criada com sucesso!", order);
        }

        public async Task<ICommandResult> Handle(MarkOrderAsDoneCommand command)
        {
            var order = _repository.GetOrderByOrderNo(command.OrderNumber);
            if (order.Done == true) return new GenericCommandResult(false, "Essa ordem ja foi finalizada!", order);
            if (order.Canceled == true) return new GenericCommandResult(false, "Essa ordem ja foi cancelada!", order);
            order.MarkAsDone();
            _repository.UpdateOrder(order);

            return new GenericCommandResult(true, "Ordem finalizada com sucesso!", order);
        }

        public async Task<ICommandResult> Handle(MarkOrderAsCancelledCommand command)
        {
            var order = _repository.GetOrderByOrderNo(command.OrderNumber);
            if (order.Done == true) return new GenericCommandResult(false, "Essa ordem ja foi finalizada!", order);
            if (order.Canceled == true) return new GenericCommandResult(false, "Essa ordem ja foi cancelada!", order);
            order.MarkAsCancelled();
            _repository.UpdateOrder(order);

            return new GenericCommandResult(true, "Ordem finalizada com sucesso!", order);
        }
    }
}