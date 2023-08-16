using ClientManager.Domain.Entities;

namespace ClientManager.Domain.Repositories
{
    public interface IClientManagerRepository
    {   
        Order GetOrderByOrderNo(string orderNumber);
        Task<IEnumerable<Order>> GetOrdersList();

        Task<IEnumerable<Order>> GetVendorOrdersList(int vendorCode);
        Task<IEnumerable<Order>> GetClientOrdersList(int clientCode);
        void CreateOrder(Order order);
        void UpdateOrder(Order order);

        Client GetClient(int clientCode);
        void CreateClient(Client client);

        Task<Vendor> GetVendor(int vendorCode);
        void CreateVendor(Vendor vendor);
    }
}