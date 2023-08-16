

using ClientManager.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace ClientManager.Domain.Commands
{
    public class CreateClientCommand : Notifiable, ICommand
    {
        public CreateClientCommand(int clientCode, string name, string documentNo, string address) 
        {   
            ClientCode = clientCode;
            Name = name;
            DocumentNo = documentNo;
            Address = address;
               
        }   
        public int ClientCode { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set;}
        public string DocumentNo { get; private set; }



        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
            );
        }
    }
}