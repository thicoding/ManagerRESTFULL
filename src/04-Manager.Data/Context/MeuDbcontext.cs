using _02_Manager.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace _04_Manager.Data.Context{

    public class MeuDbContext : DbContext{
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; } // Mapeamento da tabela Produtos

        
    }

}