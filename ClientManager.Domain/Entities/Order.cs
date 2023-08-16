
namespace ClientManager.Domain.Entities
{
    public class Order : Entity
    {
        public Order(string orderNumber, int clientCode, int vendorCode, DateTime createdAt) 
        {
            ClientCode = clientCode;
            VendorCode = vendorCode;
            OrderNumber = orderNumber;
            Done = false;
            CreatedAt = createdAt;
        }

        public int ClientCode { get; set; }
        public int VendorCode { get; set; }
        public string OrderNumber { get; private set; }
        public bool Done { get; set; }
        public bool Canceled { get; set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime ArrivedAt { get; set; }

        public void MarkAsDone(){
            Done = true;
            ArrivedAt = DateTime.Now;
        }

        public void MarkAsCancelled(){
            Canceled = true;
        }

        public virtual Client Client { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}