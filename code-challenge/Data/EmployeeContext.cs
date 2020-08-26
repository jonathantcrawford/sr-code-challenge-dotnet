using challenge.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }



        public Employee GetById(string id)
        {
            return Employees.Include(e => e.DirectReports).Where(e => e.EmployeeId == id).SingleOrDefault();
        }

    }
}
