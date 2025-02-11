using Binding.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MVC_1.Models
{
    public class FristEntity : IdentityDbContext<ApplicationUser>

    {
        public FristEntity(DbContextOptions<FristEntity> options)
        : base(options)
        {
        }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Instructor> Instructor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Options (DBMS , Authantication , dbName , instance)

            optionsBuilder.UseSqlServer("Data Source=WAFAA;Initial Catalog= MVCPractice;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

            base.OnConfiguring(optionsBuilder);
        }

    }
}
