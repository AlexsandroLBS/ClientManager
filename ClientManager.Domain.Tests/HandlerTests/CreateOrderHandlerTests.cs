using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientManager.Domain.Commands;
using ClientManager.Domain.Handlers;
using ClientManager.Domain.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClientManager.Domain.Tests.HandlerTests
{
    [TestClass]
    public class CreateOrderHandlerTests
    {
        [TestMethod]
        public void ShouldFailForAInvalidCommand()
        {
            var command = new CreateOrderCommand("", 0, 0);
            var handler = new OrderHandler(new FakeCreateOrderRepository());
            var result = (GenericCommandResult) handler.Handle(command);
        
            Assert.AreEqual(result.Success, false);
        }

        [TestMethod]
        public void ShouldPassForAInvalidCommand()
        {
            var command = new CreateOrderCommand("123", 0, 0);
            var handler = new OrderHandler(new FakeCreateOrderRepository());
            var result = (GenericCommandResult) handler.Handle(command);
        
            Assert.AreEqual(result.Success, true);
        }
    }
}