using Microsoft.EntityFrameworkCore;
using Employee_Table.Models;


namespace Employee_Table.DAL
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options)
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
