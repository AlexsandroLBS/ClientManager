using ClientManager.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;


namespace ClientManager.Domain.Commands
{
    public class CreateVendorCommand : Notifiable, ICommand
    {
        public CreateVendorCommand(string name, string email, string cellPhone) 
        {   
            Name = name;
            Email = email;
            CellPhone = cellPhone;
               
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }


        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    // .HasMinLen(CellPhone, 8, "CellPhone", "Por favor, insira um telefone válido")
                    // .IsEmail(Email, "Email", "Por favor, insira um email valido")
                    // .IsNullOrEmpty(Name, "Name", "Por favor, insira nome")
            );
        }

    }
}