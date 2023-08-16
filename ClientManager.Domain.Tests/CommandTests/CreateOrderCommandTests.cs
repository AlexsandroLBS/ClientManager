using ClientManager.Domain.Commands;

namespace ClientManager.Domain.Tests.CommandTests;

[TestClass]
public class CreateOrderCommandTests
{
    [TestMethod]
    public void ShouldFailedWithInvalidCommand()
    {
        var command = new CreateOrderCommand("", 0, 0);
        command.Validate();
        Assert.AreEqual(command.Valid, false);
    }

    [TestMethod]
     public void ShouldPassWithValidCommand()
    {
        var command = new CreateOrderCommand("123", 0, 0);
        command.Validate();
        Assert.AreEqual(command.Valid, true);
    }
}