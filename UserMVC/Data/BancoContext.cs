using Microsoft.EntityFrameworkCore;
using UserMVC.Models;

namespace UserMVC.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base (options)
        { }
        public DbSet<ContatoModel> Contatos { get; set; }
    }
}
