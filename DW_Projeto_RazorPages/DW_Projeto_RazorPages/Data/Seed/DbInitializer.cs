using DW_Projeto_RazorPages.Data.Model;
using Microsoft.AspNetCore.Identity;

namespace DW_Projeto_RazorPages.Data.Seed
{
    internal class DbInitializer
    {

        internal static async void Initialize(ApplicationDbContext dbContext)
        {

            /*
             * https://stackoverflow.com/questions/70581816/how-to-seed-data-in-net-core-6-with-entity-framework
             * 
             * https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-6.0#initialize-db-with-test-data
             * https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/data/ef-mvc/intro/samples/5cu/Program.cs
             * https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0300
             */


            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();

            // var auxiliar
            bool haAdicao = false;

            // Se não houver Subscrições, cria-as
            var subscripts = Array.Empty<Subscription>();
            if (!dbContext.Subscriptions.Any())
            {
                subscripts = [
                    new Subscription{ Name="Novatos",  Fee=49.99M, SubscriptProgram="Começe a jogar"},
                    new Subscription{ Name="Experts",  Fee=149.99M, SubscriptProgram="Alta competição"}
                ];
                await dbContext.Subscriptions.AddRangeAsync(subscripts);
                haAdicao = true;
            }

            // se não houver 'roles' cria-as
            if (dbContext.Roles.Count() == 0)
            {
                await dbContext.Roles.AddRangeAsync(
                     new IdentityRole { Id = "tr", Name = "Trainer", NormalizedName = "TRAINER" },
                     new IdentityRole { Id = "adm", Name = "Administrativo", NormalizedName = "ADMINISTRATIVO" }
                  );
                haAdicao = true;
            }

            // Se não houver Utilizadores Identity, cria-os
            var users = Array.Empty<IdentityUser>();
            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<IdentityUser>();

            if (!dbContext.Users.Any())
            {
                var user1 = new IdentityUser
                {
                    UserName = "joao_graca",
                    NormalizedUserName = "JOAO_GRACA",
                    Email = "joao.graca@ipt.pt",
                    NormalizedEmail = "JOAO.GRACA@IPT.PT",
                    EmailConfirmed = true,
                    SecurityStamp = "5ZPZEF6SBW7IU4M344XNLT4NN5RO4GRU",
                    ConcurrencyStamp = "c86d8254-dd50-44be-8561-d2d44d4bbb2f"
                };
                user1.PasswordHash = hasher.HashPassword(user1, "Aa0_aa");

                var user2 = new IdentityUser
                {
                    UserName = "afonso_gomes",
                    NormalizedUserName = "AFONSO_GOMES",
                    Email = "afonso.gomes@ipt.pt",
                    NormalizedEmail = "AFONSO.GOMES@IPT.PT",
                    EmailConfirmed = true,
                    SecurityStamp = "TW49PF6SBW7IU4M344XNLT4NN5RO4GRU",
                    ConcurrencyStamp = "d8254c86-dd50-44be-8561-d2d44d4bbb2f"
                };
                user2.PasswordHash = hasher.HashPassword(user2, "Aa0_aa");

                var user3 = new IdentityUser
                {
                    UserName = "Membro00001",
                    NormalizedUserName = "MEMBRO00001@IPT.PT",
                    Email = "membro00001",
                    NormalizedEmail = "MEMBRO00001@IPT.PT",
                    EmailConfirmed = true,
                    SecurityStamp = "TW49PF6SBW7IU4M344XNLT4NN5RO4GRU",
                    ConcurrencyStamp = "d8254c86-dd50-44be-8561-d2d44d4bbb2f"
                };
                user3.PasswordHash = hasher.HashPassword(user3, "Aa0_aa");

                users = new[] { user1, user2, user3 };
                await dbContext.Users.AddRangeAsync(users);


                // associar os 'Treinadores' à role 'Treinador'
                await dbContext.UserRoles.AddRangeAsync(
                     new IdentityUserRole<string> { UserId = users[0].Id, RoleId = "tr" },
                     new IdentityUserRole<string> { UserId = users[1].Id, RoleId = "tr" }
                  );

                haAdicao = true;
            }

            // Se não houver Membros, cria-os
            var membr = Array.Empty<Member>();
            if (!dbContext.Members.Any())
            {
                membr = [
                    new Member{ Name="Mário Lopes", BirthDate=DateOnly.Parse("2000-12-15"),CellPhone="" ,
                       SubscriptionFK= subscripts[0].Id, RegistrationDate=DateTime.Parse("2024-02-15"), MemberNumber=1,
                       UserID=users[2].Id},
                    new Member{ Name="Joana Gomes", BirthDate=DateOnly.Parse("2000-12-16"),CellPhone="913456789" ,
                       SubscriptionFK= subscripts[0].Id, RegistrationDate=DateTime.Parse("2024-12-15"), MemberNumber=2},
                    new Member{ Name="João Silva", BirthDate=DateOnly.Parse("1999-12-31"),CellPhone="92345687" ,
                       SubscriptionFK= subscripts[0].Id, RegistrationDate=DateTime.Parse("2024-12-15"), MemberNumber=3},
                    new Member{ Name="Maria Santos", BirthDate=DateOnly.Parse("2000-12-15"),CellPhone="9612347" ,
                       SubscriptionFK= subscripts[1].Id, RegistrationDate=DateTime.Parse("2026-12-15"), MemberNumber=4},
                    new Member{ Name="Ana Costa", BirthDate=DateOnly.Parse("2000-12-15"),CellPhone="" ,
                       SubscriptionFK= subscripts[1].Id, RegistrationDate=DateTime.Parse("2026-12-15"), MemberNumber=5},
        ];
                await dbContext.Members.AddRangeAsync(membr);
                haAdicao = true;
            }



            // Se não houver Funcionarios, cria-os
            var trainers = Array.Empty<Employee>();
            if (!dbContext.Employees.Any())
            {
                trainers = [
                    new Employee { Name="João Graça", BirthDate=DateOnly.Parse("1970-04-10"), CellPhone="919876543" , UserID=users[0].Id },
                    new Employee { Name="Afonso Gomes", BirthDate=DateOnly.Parse("1988-09-12"), CellPhone="918076543" , UserID=users[1].Id }
                  ];
                await dbContext.Employees.AddRangeAsync(trainers);
                haAdicao = true;
            }


            //TODO
            // Se não houver Campos, cria-os
            var fld = Array.Empty<Field>();
            if (!dbContext.Fields.Any())
            {
                fld = [
                    new Field{},
                    new Field{},
                    new Field{},
                    new Field{}
                ];
                await dbContext.Fields.AddRangeAsync(fld);
                haAdicao = true;
            }

            //TODO - Match


            try
            {
                if (haAdicao)
                {
                    // tornar persistentes os dados
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }

}
