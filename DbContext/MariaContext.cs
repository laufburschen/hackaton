using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.DbContext
{
    public class MariaContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public MariaContext(DbContextOptions<MariaContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
         
    }
}