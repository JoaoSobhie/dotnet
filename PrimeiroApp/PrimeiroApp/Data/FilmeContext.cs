using Microsoft.EntityFrameworkCore;
using PrimeiroApp.Models;

namespace PrimeiroApp.Data
{
    
    public class FilmeContext: DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opts): base(opts)
        {

        }
        public DbSet<Filme> Filmes { get; set; }
    }
}
