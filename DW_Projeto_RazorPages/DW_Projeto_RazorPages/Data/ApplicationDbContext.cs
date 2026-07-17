using DW_Projeto_RazorPages.Data.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DW_Projeto_RazorPages.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        // Tabela dos utilizadores da aplicação do clube
        public DbSet<MyUser> AppUsers { get; set; }
        // Tabela dos membros do clube
        public DbSet<Member> Members { get; set; }
        // Tabela das subscrições do clube
        public DbSet<Subscription> Subscriptions { get; set; }
        // Tabela de campos de ténis do clube
        public DbSet<Field> Fields { get; set; }
        // Tabela de jogos / partidas realizadas no clube
        public DbSet<Match> Matches { get; set; }
        // Tabela intermédia: participantes em cada jogo
        public DbSet<MatchParticipant> MatchParticipants { get; set; }
        // Tabela dos funcionarios
        public DbSet<Employee> Employees { get; set; }
    }
}