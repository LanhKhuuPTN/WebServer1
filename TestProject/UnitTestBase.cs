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
   
    public class UnitTestBase
    {
        protected readonly PaymentDetailContext _context;
        public UnitTestBase()
        {
            var option = new DbContextOptionsBuilder<PaymentDetailContext>().UseSqlServer("Data Source=DESKTOP-JSO045V\\MSSQLSERVER2019;Initial Catalog=master;User ID=sa;Password=lanh12345;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False").Options;
            _context = new PaymentDetailContext(option);
        }
    }
}
