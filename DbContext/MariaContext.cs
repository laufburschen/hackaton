using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.DbContext
{
    public class MariaContext: Microsoft.EntityFrameworkCore.DbContext
    {

            //entities
            public DbSet<Order> Persons { get; set; }

    }
}
