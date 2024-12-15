using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TrainingDbContext : DbContext
    {
        public TrainingDbContext() // this is needed so that OnConfiguring can run
        {

        }

        public TrainingDbContext(DbContextOptions option): base(option)
        {

        }
        //for configuring connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //since we have passed it from dependencies so it will not get called
            if (!optionsBuilder.IsConfigured) { 
                string connectionString = "Data Source=LAPTOP-VA38D82T;Initial Catalog=aspnetcoretraining;Integrated Security=true;Trust Server Certificate=true";
                optionsBuilder.UseSqlServer(connectionString);
                base.OnConfiguring(optionsBuilder);
            }
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
