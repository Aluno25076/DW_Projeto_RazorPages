using DW_Projeto_RazorPages.Data.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DW_Projeto_RazorPages.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        /// <summary>
        /// Tabela dos utilizadores da aplicação do clube 
        /// </summary>
        public DbSet<MyUser> AppUsers { get; set; }

        /// <summary>
        /// Tabela dos membros do clube
        /// </summary>        
        public DbSet<Member> Members { get; set; }

        /// <summary>
        /// Tabela das subscrições do clube
        /// </summary>
        public DbSet<Subscription> Subscriptions { get; set; }

        /// <summary>
        /// Tabela de campos de ténis do clube
        /// </summary>
        public DbSet<Field> Fields { get; set; }

        /// <summary>
        /// Tabela de jogos / partidas realizadas no clube
        /// </summary>
        public DbSet<Match> Matches { get; set; }

        /// <summary>
        /// Tabela dos funcionarios
        /// </summary>
        public DbSet<Employee> Employees { get; set; }
    }
}