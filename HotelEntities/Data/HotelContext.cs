using HotelEntities.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelEntities.Data
{
    public class HotelContext : DbContext
    {
        public HotelContext() { }
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {
        }
        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CheckOut> CheckOuts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer("Data Source=DESKTOP-EN72J61\\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True;TrustServerCertificate=True;");
    }
}
