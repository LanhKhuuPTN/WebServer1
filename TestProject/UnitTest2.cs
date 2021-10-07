using System;
using Xunit;
using WebServer.Controllers;
using WebServer.Models;
using FakeItEasy;
using Moq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TestProject
{
    public class UnitTest2: UnitTestBase
    {
        [Fact]
        public async void GetPayment_ReturnALLCustomer()
        {

            var controller = new PaymentDetailGUIDsController(_context);
            var result = await controller.GetPaymentDetailGUIDs();
            // var objectResult = Assert.IsType<OkObjectResult>(AllPayment);
            var customers = Assert.IsAssignableFrom<IEnumerable<PaymentDetailGUID>>(result.Value);
            Assert.Equal(2, customers.Count());
        }

        [Fact]
        public async void GetPayment_ReturnCorrectType()
        {
            var controller = new PaymentDetailGUIDsController(_context);
           // var id = Guid.Parse("3A6543FF-5788-45EC-02C7-08D9889392EB");
            var result = await controller.GetPaymentDetailGUIDs();
            Assert.IsAssignableFrom<IEnumerable<PaymentDetailGUID>>(result.Value);
        }

        [Fact]
        public async Task GetPayment_ReturnNotFount_Invalid()
        {
            var controller = new PaymentDetailGUIDsController(_context);
            var id = Guid.Parse("3A6543FF-5788-45EC-02C7-08D9889392E3");
            var result = await controller.GetPaymentDetailGUID(id);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetPayment_ReturnPayment_valid()
        {
            var controller = new PaymentDetailGUIDsController(_context);
            var id = Guid.Parse("3A6543FF-5788-45EC-02C7-08D9889392EB"); 
            var result = await controller.GetPaymentDetailGUID(id);
            var Payment = Assert.IsAssignableFrom<PaymentDetailGUID>(result.Value);
            Assert.Equal("KV1234", Payment.CardOwerName);
        }
        [Fact]
        public async Task DeletePayment_ReturnNofound()
        {
            var controller = new PaymentDetailGUIDsController(_context);
            var id = Guid.Parse("3A6543FF-5788-45EC-02C7-08D9889392EC");
            var result = await controller.DeletePaymentDetailGUID(id);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task UpdatePaymnet_Invalid()
        {
            var controller = new PaymentDetailGUIDsController(_context);
            PaymentDetailGUID pm = new PaymentDetailGUID();
            pm.CardOwerName = "KV1234";
            pm.CardNumber = "2323232323";
            pm.ExpirationDate = "12/21";
            pm.SecurityCode = "122";
            var id = Guid.Parse("3A6543FF-5788-45EC-02C7-08D9889392EC");
            var result = await controller.PutPaymentDetailGUID(id, pm);
            Assert.IsType<BadRequestResult>(result);
        }
        [Fact]
        public async Task UpdatePaymnet_valid()
        {
            var controller = new PaymentDetailGUIDsController(_context);
            PaymentDetailGUID pm = new PaymentDetailGUID();
            pm.CardOwerName = "KV1234";
            pm.CardNumber = "2323232323";
            pm.ExpirationDate = "12/21";
            pm.SecurityCode = "122";
            var id = Guid.Parse("3A6543FF-5788-45EC-02C7-08D9889392EB");
            pm.Id = id;
            var result = await controller.PutPaymentDetailGUID(id, pm);
            Assert.IsType<NoContentResult>(result);
        }
    }
}
