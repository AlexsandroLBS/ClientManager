using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientManager.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClientManager.Domain.Tests.EntitiesTests
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var order = new Order("", 0, 0, new DateTime());
            Assert.AreEqual(order.Done, false);
        }
    }
}