using CRUDCadastroProdutos.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CRUDCadastroProdutos.Data
{
    public class MVCDbContext : DbContext
    {
        public MVCDbContext(DbContextOptions options) : base(options)
        {            
        }

        public virtual DbSet<Product> Products { get; set; }
    }
}
