using ClientManager.Domain.Entities;
using ClientManager.Domain.Repositories;

namespace ClientManager.Domain.Tests.Repositories
{
    public class FakeCreateOrderRepository : IClientManagerRepository
    {
        public Task CreateClient(Client client)
        {
            throw new NotImplementedException();
        }

        public Task CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Task CreateVendor(Vendor vendor)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Client>> GetAllClients()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Vendor>> GetAllVendors()
        {
            throw new NotImplementedException();
        }

        public Client GetClient(int clientCode)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetClientOrdersList(int clientCode)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderByOrderNo(string orderNumber)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetOrdersList()
        {
            throw new NotImplementedException();
        }

        public Task<Vendor> GetVendor(int vendorCode)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetVendorOrdersList(int vendorCode)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}