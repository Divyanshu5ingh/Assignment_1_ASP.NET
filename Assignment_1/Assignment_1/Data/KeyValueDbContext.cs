using Assignment_1.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_1.Data
{
    public class KeyValueDbContext : DbContext
    {
        public KeyValueDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<KeyValue> KeyValues { get; set; }
    }
}
