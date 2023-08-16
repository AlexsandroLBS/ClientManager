
namespace ClientManager.Domain.Entities
{
    public class Entity
    {
        public Entity()
        {
            Id = new Guid();
        }
        public Guid Id { get; private set;}
    }
}