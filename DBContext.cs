using CarsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CarsApi
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        public DbSet<users> Users { get; set; }
    }
}
