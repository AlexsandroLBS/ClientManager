using System.ComponentModel.DataAnnotations;

namespace ClientManager.Domain.Entities
{
    public class Vendor //: Entity
    {
        public Vendor( int vendorCode, string name, string email, string cellPhone) 
        {   
            VendorCode = vendorCode;
            Name = name;
            Email = email;
            CellPhone = cellPhone;

        }
        
        public int VendorCode { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string CellPhone { get; private set; }

    }
}