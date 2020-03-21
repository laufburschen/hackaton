using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.DbContext
{
    public class MariaContext: Microsoft.EntityFrameworkCore.DbContext
    {

        public DbSet<Order> Orders { get; set; }
    }
}