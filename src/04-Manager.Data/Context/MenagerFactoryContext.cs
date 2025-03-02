using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace _04_Manager.Data.Context
{
    public class MenagerContextFactory : IDesignTimeDbContextFactory<MenagerContext>
    {
        public MenagerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MenagerContext>();

            // Usando MariaDB com Pomelo.EntityFrameworkCore.MySql
            optionsBuilder.UseMySql("Server=localhost;Database=user;User=thicodes;Password=818181;", 
                new MySqlServerVersion(new Version(10, 5, 9))); // Versão do MariaDB (ajuste conforme necessário)

            return new MenagerContext(optionsBuilder.Options);
        }
    }
}
