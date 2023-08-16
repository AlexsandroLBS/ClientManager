using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientManager.Domain.Commands.Contracts;
using Flunt.Notifications;

namespace ClientManager.Domain.Commands
{
    public class MarkOrderAsCancelledCommand : Notifiable, ICommand
    {
        public MarkOrderAsCancelledCommand(string orderNumber)
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