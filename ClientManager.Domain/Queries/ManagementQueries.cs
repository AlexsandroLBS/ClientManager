

using System.Linq.Expressions;
using ClientManager.Domain.Entities;

namespace ClientManager.Domain.Queries
{
    public static class ManagementQueries
    {
        public static Expression<Func<Order, bool>> GetOrderByNo(string orderNo)
        {
            return x => x.OrderNumber == orderNo;
        }
        public static Expression<Func<Order, bool>> GetDoneOrders()
        {
            return x => x.Done == true;
        }

         public static Expression<Func<Order, bool>> GetUndoneOrders()
        {
            return x => x.Done == false && x.Canceled == false;
        }

        public static Expression<Func<Order, bool>> GetCancelledOrders()
        {
            return x => x.Canceled == true;
        }

        public static Expression<Func<Client, bool>> GetClientByCode(int clientCode)
        {
            return x => x.ClientCode == clientCode;
        }
        public static Expression<Func<Vendor, bool>> GetVendorByCode(int vendorCode)
        {
            return x => x.VendorCode == vendorCode;
        }
    }
}