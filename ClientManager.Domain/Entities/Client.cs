

using System.ComponentModel.DataAnnotations;

namespace ClientManager.Domain.Entities
{
     public class Client //: Entity
    {
        public Client( string name, string documentNo, string address)
        {
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