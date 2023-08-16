using ClientManager.Domain.Entities;

namespace ClientManager.Domain.Repositories
{
    public interface IClientManagerRepository
    {   
        Order GetOrderByOrderNo(string orderNumber);
        Task<IEnumerable<Order>> GetOrdersList();

        Task<IEnumerable<Order>> GetVendorOrdersList(int vendorCode);
        Task<IEnumerable<Order>> GetClientOrdersList(int clientCode);
        Task CreateOrder(Order order);
        void UpdateOrder(Order order);

        Client GetClient(int clientCode);
        Task CreateClient(Client client);
        Task<Vendor> GetVendor(int vendorCode);
        Task CreateVendor(Vendor vendor);

        Task<IEnumerable<Client>> GetAllClients();
        Task<IEnumerable<Vendor>> GetAllVendors();
    }
}