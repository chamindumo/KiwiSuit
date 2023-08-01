using Microsoft.EntityFrameworkCore;
using KiwiSuit.Models;
using KiwiSuit.DTO;

namespace KiwiSuit.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Books> Books { get; set; }
        public DbSet<BookDTO> BookDTO { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductDTO> ProductDTO { get; set; }

    }
}
