using ClientManager.Domain.Entities;
using ClientManager.Domain.Repositories;

namespace ClientManager.Domain.Tests.Repositories
{
    public class FakeCreateOrderRepository : IClientManagerRepository
    {
        public void CreateClient(Client client)
        {
            throw new NotImplementedException();
        }

        public void CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void CreateVendor(Vendor vendor)
        {
            throw new NotImplementedException();
        }

        public Client GetClient(int clientCode)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetClientOrdersList(int clientCode)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderByOrderNo(string orderNumber)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrdersList()
        {
            throw new NotImplementedException();
        }

        public Vendor GetVendor(int vendorCode)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetVendorOrdersList(int vendorCode)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}