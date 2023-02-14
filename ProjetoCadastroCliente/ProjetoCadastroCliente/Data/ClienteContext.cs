using Microsoft.EntityFrameworkCore;
using ProjetoCadastroCliente.Models;

namespace ProjetoCadastroCliente.Data
{
    public class ClienteContext: DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> opts): base(opts) 
        {
        
        }

        public DbSet<Cliente> Cliente { get; set; }
    }
}
