using DW_Projeto_RazorPages.Data.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace DW_Projeto_RazorPages.Data
{
    /// <summary>
    /// Contexto principal da base de dados da aplicação do clube de ténis.
    /// Herda de IdentityDbContext para suportar autenticação por Individual Accounts.
    /// Utiliza Entity Framework Core com abordagem Code First.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext
    {
        // Construtor que recebe as opções de configuração do contexto
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Tabela de utilizadores base (MyUser com herança TPH)
        public DbSet<MyUser> MyUsers { get; set; }

        // Tabela de membros / sócios do clube
        public DbSet<Member> Members { get; set; }

        // Tabela de funcionários do clube
        public DbSet<Employee> Employees { get; set; }

        // Tabela de subscrições / planos disponíveis no clube
        public DbSet<Subscription> Subscriptions { get; set; }

        // Tabela intermédia: associação entre membros e subscrições
        public DbSet<MemberSubscription> MemberSubscriptions { get; set; }

        // Tabela de campos de ténis do clube
        public DbSet<Field> Fields { get; set; }

        // Tabela de jogos / partidas realizadas no clube
        public DbSet<Match> Matches { get; set; }

        // Tabela intermédia: participantes em cada jogo
        public DbSet<MatchParticipant> MatchParticipants { get; set; }

        /// <summary>
        /// Configuração do modelo de dados usando a Fluent API do Entity Framework Core.
        /// Define chaves primárias compostas, relações e restrições adicionais.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Chama a configuração base do IdentityDbContext (obrigatório)
            base.OnModelCreating(modelBuilder);

            // Configuração da herança TPH (Table Per Hierarchy) para MyUser
            // Todos os tipos derivados ficam na mesma tabela com um discriminador automático
            modelBuilder.Entity<MyUser>()
                .HasDiscriminator<string>("UserType")
                .HasValue<MyUser>("User")
                .HasValue<Member>("Member")
                .HasValue<Employee>("Employee");

            // Configuração da chave primária composta da tabela intermédia MemberSubscription
            modelBuilder.Entity<MemberSubscription>()
                .HasKey(ms => new { ms.MemberId, ms.SubscriptionId });

            // Configuração da relação entre MemberSubscription e Member
            modelBuilder.Entity<MemberSubscription>()
                .HasOne(ms => ms.Member)
                .WithMany(m => m.MemberSubscriptions)
                .HasForeignKey(ms => ms.MemberId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuração da relação entre MemberSubscription e Subscription
            modelBuilder.Entity<MemberSubscription>()
                .HasOne(ms => ms.Subscription)
                .WithMany(s => s.MemberSubscriptions)
                .HasForeignKey(ms => ms.SubscriptionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuração da chave primária composta da tabela intermédia MatchParticipant
            modelBuilder.Entity<MatchParticipant>()
                .HasKey(mp => new { mp.MatchId, mp.MemberId });

            // Configuração da relação entre MatchParticipant e Match
            modelBuilder.Entity<MatchParticipant>()
                .HasOne(mp => mp.Match)
                .WithMany(m => m.MatchParticipants)
                .HasForeignKey(mp => mp.MatchId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuração da relação entre MatchParticipant e Member
            modelBuilder.Entity<MatchParticipant>()
                .HasOne(mp => mp.Member)
                .WithMany(m => m.MatchParticipants)
                .HasForeignKey(mp => mp.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração da relação entre Match e Field
            modelBuilder.Entity<Match>()
                .HasOne(m => m.Field)
                .WithMany(f => f.Matches)
                .HasForeignKey(m => m.FieldId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

