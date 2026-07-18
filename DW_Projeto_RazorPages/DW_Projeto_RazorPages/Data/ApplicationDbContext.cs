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
        // Tabela dos funcionarios
        public DbSet<Employee> Employees { get; set; }
        // Tabela de resultados dos jogos / partidas
        public DbSet<Result> Results { get; set; }

        /// <summary>
        /// Configuração do modelo de dados usando a Fluent API
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Chama a configuração base do IdentityDbContext (obrigatório)
            base.OnModelCreating(modelBuilder);


            // 1 jogo só pode ter 1 resultado, e cada resultado pertence a 1 jogo
            modelBuilder.Entity<Result>()
                .HasOne(r => r.Match)
                .WithOne(m => m.Result)
                .HasForeignKey<Result>(r => r.MatchFK);
        }

    }
}