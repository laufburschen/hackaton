using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.DbContext
{
    public class PersonContext: Microsoft.EntityFrameworkCore.DbContext
    {

            //entities
            public DbSet<Person> Persons { get; set; }

    }
}
