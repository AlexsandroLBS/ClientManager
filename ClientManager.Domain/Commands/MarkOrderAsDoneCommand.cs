using ClientManager.Domain.Commands.Contracts;

namespace ClientManager.Domain.Commands
{
    public class MarkOrderAsDoneCommand : ICommand
    {
        public MarkOrderAsDoneCommand(string orderNumber)
        {
            OrderNumber = orderNumber;
        }

        public string OrderNumber { get; set; }
        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}