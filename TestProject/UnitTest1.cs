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
    public class UnitTest1: UnitTestBase
    {
        
        [Fact]
        public async void GetPayment_ReturnALLCustomer()
        {
            
            var controller = new PaymentDetailsController(_context);
            var result =  await controller.GetPaymentDetails();
           // var objectResult = Assert.IsType<OkObjectResult>(AllPayment);
            var customers = Assert.IsAssignableFrom<IEnumerable<PaymentDetail>>(result.Value);
            Assert.Equal(3, customers.Count());
          }

        [Fact]
        public async void GetPayment_ReturnCorrectType()
        {
            var controller = new PaymentDetailsController(_context);
            var result = await controller.GetPaymentDetails();
            Assert.IsAssignableFrom<IEnumerable<PaymentDetail>>(result.Value);
        }

        [Fact]
        public async Task GetPayment_ReturnNotFount_Invalid()
        {
            var controller = new PaymentDetailsController(_context);
            var result = await controller.GetPaymentDetail(9);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetPayment_ReturnPayment_valid()
        {
            var controller = new PaymentDetailsController(_context);
            var result = await controller.GetPaymentDetail(12);
            var Payment =  Assert.IsAssignableFrom<PaymentDetail>(result.Value);
            Assert.Equal("lanh1234", Payment.CardOwerName);
        }
        [Fact]
         public async Task DeletePayment_ReturnNofound()
        {
            var controller = new PaymentDetailsController(_context);
            var result = await controller.DeletePaymentDetail(11);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task UpdatePaymnet_Invalid()
        {
            var controller = new PaymentDetailsController(_context);
            PaymentDetail pm = new PaymentDetail();
            pm.CardOwerName = "KV1234";
            pm.CardNumber = "2323232323";
            pm.ExpirationDate = "12/21";
            pm.SecurityCode = "122";
            var result = await controller.PutPaymentDetail(1, pm);
            Assert.IsType<BadRequestResult>(result);
        }
        [Fact]
        public async Task UpdatePaymnet_valid()
        {
            var controller = new PaymentDetailsController(_context);
            PaymentDetail pm = new PaymentDetail();
            pm.CardOwerName = "KV1234";
            pm.CardNumber = "2323232323";
            pm.ExpirationDate = "12/21";
            pm.SecurityCode = "122";
            pm.Id = 25;
            var result = await controller.PutPaymentDetail(25, pm);
            Assert.IsType<NoContentResult>(result);
        }
    }
}
