

using System.ComponentModel.DataAnnotations;

namespace ClientManager.Domain.Entities
{
     public class Client //: Entity
    {
        public Client(int clientCode, string name, string documentNo, string address)
        {
            ClientCode = clientCode;
            Name = name;
            DocumentNo = documentNo;
            Address = address; 
        }
        [Key]
        public int ClientCode { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set;}
        public string DocumentNo { get; private set; }

    }
}