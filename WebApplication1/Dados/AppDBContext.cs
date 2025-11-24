using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Dados
{
    //Utilizando o EF
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
