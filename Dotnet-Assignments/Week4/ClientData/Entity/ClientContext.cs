using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Entities
{
    public class ClientContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ClientContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source = localhost; Database = CustomerDB; integrated security = True;");
        }

        public DbSet<ClientData>? Client { get; set; }

        public DbSet<Adress>? Adress { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientData>();
            modelBuilder.Entity<Adress>();
        }
    }
}
