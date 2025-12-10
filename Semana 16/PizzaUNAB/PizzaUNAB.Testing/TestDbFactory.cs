using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaUNAB.Infrastructure.Data;

namespace PizzaUNAB.Testing
{
    public class TestDbFactory
    {
        public static PizzeriaDb CreateInMemory()
        {
            var options = new DbContextOptionsBuilder<PizzeriaDb>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var db = new PizzeriaDb(options);
            return db;
        }

        
    }
}
