
using ClientManager.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace ClientManager.Domain.Commands
{
    public class CreateOrderCommand : Notifiable, ICommand
    {

        public CreateOrderCommand(string orderNumber, int clientCode, int vendorCode) 
        {   
            ClientCode = clientCode;
            VendorCode = vendorCode;
            OrderNumber = orderNumber;
            CreatedAt = DateTime.Now;
        }   
        public int ClientCode { get; set; }
        public int VendorCode { get; set; }
        public string OrderNumber { get; private set; }


        public DateTime CreatedAt { get; private set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(OrderNumber, 1, "OrderNumber", "Por favor, insira um numero de pedido")
            );
        }
    }
}