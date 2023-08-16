
using ClientManager.Domain.Entities;
using ClientManager.Domain.Infra.Context;
using ClientManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClientManager.Domain.Infra.Repositories
{
    public class ClientManagerRepository : IClientManagerRepository
    {   
        private readonly DataContext _context;

        public ClientManagerRepository(DataContext context)
        {
            _context = context;
        }
        public void CreateClient(Client client)
        {
            _context.Clients.AddAsync(client);
            _context.SaveChangesAsync();
        }

        public void CreateOrder(Order order)
        {
            _context.Orders.AddAsync(order);
            _context.SaveChangesAsync();
        }

        public void CreateVendor(Vendor vendor)
        {
            _context.Vendors.AddAsync(vendor);
            _context.SaveChangesAsync();
        }

        public  Client GetClient(int clientCode)
        {
            var client = _context.Clients.First(x => x.ClientCode == clientCode);
            return client;
        }

        public async Task<IEnumerable<Order>> GetClientOrdersList(int clientCode)
        {
            var orders = await _context.Orders.Where(x => x.ClientCode == clientCode).ToListAsync();
            return orders;
        }

        public  Order GetOrderByOrderNo(string orderNumber)
        {
            var order = _context.Orders.First(o => o.OrderNumber == orderNumber);
            return order;
        }

        public async Task<IEnumerable<Order>> GetOrdersList()
        {
            var orders = await _context.Orders.ToListAsync();
            return orders;
        }

        public async Task<Vendor> GetVendor(int vendorCode)
        {
            var vendor = await _context.Vendors.FirstOrDefaultAsync(v => v.VendorCode == vendorCode);
            return vendor;
        }

        public async Task<IEnumerable<Order>> GetVendorOrdersList(int vendorCode)
        {
            var orders = await _context.Orders.Where(x => x.VendorCode == vendorCode).ToListAsync();
            return orders;
        }

        public void UpdateOrder(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}