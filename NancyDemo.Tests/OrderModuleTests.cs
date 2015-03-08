using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy;
using Nancy.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyDemo.Tests
{
    [TestClass]
    public class OrderModuleTests
    {
        [TestMethod]
        public void when_i_grab_orders_I_get_orders()
        {
            //Arrange
            var browser = new Browser(m => m.Module<OrderModule>());

            //Act
            var response = browser.Get("/orders", with =>
            {
                with.HttpRequest();
                with.Header("accept", "application/xml");
            });

            //var body = response.Body;
            //var order = body.DeserializeJson<Order>();

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            //Assert.AreEqual(body.)
        }

        [TestMethod]
        public void when_i_grab_a_good_order_I_get_200()
        {
            //Arrange
            var browser = new Browser(m => m.Module<OrderModule>());

            //Act
            var response = browser.Get("/orders/1", with =>
            {
                with.HttpRequest();
                with.Header("accept", "application/json");
            });


            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void when_i_grab_a_bad_order_I_get_404()
        {
            //Arrange
            var browser = new Browser(m => m.Module<OrderModule>());

            //Act
            var response = browser.Get("/orders/666", with =>
            {
                with.HttpRequest();
                with.Header("accept", "application/json");
            });


            //Assert
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
