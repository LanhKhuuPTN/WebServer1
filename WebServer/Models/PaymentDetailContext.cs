using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebServer.Models
{
    public class PaymentDetailContext : DbContext
    {
        public PaymentDetailContext(DbContextOptions<PaymentDetailContext> options): base(options)
        {

        }
        
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
        public DbSet<PaymentDetailGUID> PaymentDetailGUIDs { get; set; }
    }
}
