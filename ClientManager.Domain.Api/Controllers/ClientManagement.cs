
using ClientManager.Domain.Commands;
using ClientManager.Domain.Entities;
using ClientManager.Domain.Handlers;
using ClientManager.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClientManager.Domain.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientManagement : ControllerBase
    {   
        //Client
        [Route("client/get")]
        [HttpGet]
        public Client GetClientByClientCode(int clientCode,
            [FromServices] IClientManagerRepository _repository
            )
        {
            return _repository.GetClient(clientCode);
        }

        [Route("client/new")]
        [HttpPost]
        public GenericCommandResult CreateClient(
            [FromBody] CreateClientCommand command,
            [FromServices] ClientHandler handler
            )
        {
            return (GenericCommandResult) handler.Handle(command);
        }


        //Vendor
        [HttpPost]
        [Route("vendor/new")]
        public GenericCommandResult CreateVendor(
            [FromBody] CreateVendorCommand command,
            [FromServices] VendorHandler handler
            )
        {
            return (GenericCommandResult) handler.Handle(command);
        }

        //Orders
        [HttpPost]
        [Route("orders/new")]
        public GenericCommandResult CreateOrder(
            [FromBody] CreateOrderCommand command,
            [FromServices] OrderHandler handler
            )
        {
            return (GenericCommandResult) handler.Handle(command);
        }
    }
}