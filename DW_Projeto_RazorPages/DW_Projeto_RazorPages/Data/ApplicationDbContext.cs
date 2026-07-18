using DW_Projeto_RazorPages.Data.Model;
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
        /// <summary>
        /// Construtor que recebe as opções de configuração do contexto
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Tabela de utilizadores base (MyUser com herança TPH)
        /// </summary>
        public DbSet<MyUser> MyUsers { get; set; }

        /// <summary>
        /// Tabela de membros / sócios do clube
        /// </summary>
        public DbSet<Member> Members { get; set; }

        /// <summary>
        /// Tabela de funcionários do clube
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// Tabela de subscrições / planos disponíveis no clube
        /// </summary>
        public DbSet<Subscription> Subscriptions { get; set; }

        /// <summary>
        /// Tabela intermédia: associação entre membros e subscrições
        /// </summary>
        public DbSet<MemberSubscription> MemberSubscriptions { get; set; }

        /// <summary>
        /// Tabela de campos de ténis do clube
        /// </summary>
        public DbSet<Field> Fields { get; set; }

        /// <summary>
        /// Tabela de jogos / partidas realizadas no clube
        /// </summary>
        public DbSet<Match> Matches { get; set; }

    

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

         
            
          

       

            // Configuração da relação entre Match e Field
            modelBuilder.Entity<Match>()
                .HasOne(m => m.Field)
                .WithMany(f => f.Matches)
                .HasForeignKey(m => m.FieldId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

