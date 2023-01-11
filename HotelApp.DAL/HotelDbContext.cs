using HotelApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.DAL
{
    public class HotelDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server= DESKTOP-VE8RJ3L\\SQLEXPRESS;Database = AutDb;Trusted_Connection = True;");
        }

        public DbSet<Hotel> Hotels { get; set; }
    }
}
