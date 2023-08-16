
using ClientManager.Domain.Commands;
using ClientManager.Domain.Entities;
using ClientManager.Domain.Handlers;
using ClientManager.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClientManager.Domain.Api.Controllers
{
    [ApiController]
    [Route("api/v1")]
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

        [Route("client/getAll")]
        [HttpGet]
        public Task<IEnumerable<Client>> GetAllClients(
            [FromServices] IClientManagerRepository _repository
            )
        {
            return _repository.GetAllClients();
        }
        [Route("client/clietOrders")]
        [HttpGet]
        public Task<IEnumerable<Order>> GetClientOrdersList(int clientCode,
            [FromServices] IClientManagerRepository _repository
            )
        {
            return _repository.GetClientOrdersList(clientCode);
        }

        [Route("client/new")]
        [HttpPost]
        public async Task<GenericCommandResult> CreateClient(
            [FromBody] CreateClientCommand command,
            [FromServices] ClientHandler handler
            )
        {
            return (GenericCommandResult) await handler.Handle(command);
        }


        //Vendor

        [Route("vendor/get")]
        [HttpGet]
        public  Task<Vendor> GetVendorByCode(int vendorCode,
            [FromServices] IClientManagerRepository _repository
            )
        {
            return  _repository.GetVendor(vendorCode);
        }
        [Route("vendor/getAll")]
        [HttpGet]
        public  Task<IEnumerable<Vendor>> GetAllVendors(
            [FromServices] IClientManagerRepository _repository
            )
        {
            return  _repository.GetAllVendors();
        }

        [Route("vendor/vendorOrders")]
        [HttpGet]
        public Task<IEnumerable<Order>> GetVendorOrdersList(int vendorCode,
            [FromServices] IClientManagerRepository _repository
            )
        {
            return _repository.GetVendorOrdersList(vendorCode);
        }

        [HttpPost]
        [Route("vendor/new")]
        public async Task<GenericCommandResult> CreateVendor(
            [FromBody] CreateVendorCommand command,
            [FromServices] VendorHandler handler
            )
        {
            return (GenericCommandResult) await handler.Handle(command);
        }



        //Orders
        [HttpGet]
        [Route("orders/getOrderByOrderNo")]
        public Order GetOrderByNo(
            string orderNo,
            [FromServices] IClientManagerRepository _repository
            )
        {
            return _repository.GetOrderByOrderNo(orderNo);
        }

        [HttpGet]
        [Route("orders/getAllOrders")]
        public async Task<IEnumerable<Order>> GetOrderByNo(
            [FromServices] IClientManagerRepository _repository
            )
        {
            return await _repository.GetOrdersList();
        }

        
        
        [HttpPost]
        [Route("orders/new")]
        public async Task<GenericCommandResult> CreateOrder(
            [FromBody] CreateOrderCommand command,
            [FromServices] OrderHandler handler
            )
        {
            return (GenericCommandResult) await handler.Handle(command);
        }

        [HttpPost]
        [Route("orders/markAsDone")]
        public async Task<GenericCommandResult> FinishOrder(
            [FromBody] MarkOrderAsDoneCommand command,
            [FromServices] OrderHandler handler
            )
        {
            return (GenericCommandResult) await handler.Handle(command);
        }

        [HttpPost]
        [Route("orders/markAsCancelled")]
        public async Task<GenericCommandResult> CancelOrder(
            [FromBody] MarkOrderAsCancelledCommand command,
            [FromServices] OrderHandler handler
            )
        {
            return (GenericCommandResult) await handler.Handle(command);
        }
    }
}