using Microsoft.EntityFrameworkCore;
using _02_Manager.Domain.Entities;

namespace _04_Manager.Data.Context
{
    public class MenagerContext : DbContext
    {
        // Construtor sem parâmetros (necessário para o design-time)
        public MenagerContext() { }

        // Construtor com DbContextOptions (usado em runtime)
        public MenagerContext(DbContextOptions<MenagerContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}