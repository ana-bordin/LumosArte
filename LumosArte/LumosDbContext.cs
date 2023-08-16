using API;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class LumosDbContext : DbContext
    {
        public LumosDbContext(DbContextOptions<LumosDbContext> options) : base(options)
        {
            Database.SetCommandTimeout(200000);
        }
            
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Ajuda> Ajuda { get; set; }
        public DbSet<Assunto> Assunto { get; set; }

    }

}
