using Framework.Shared.Configuration;
using Framework.Shared.Models.Culture;
using Framework.Shared.Models.File;
using Framework.Shared.Models.Setting;
using Framework.Shared.Models.Template;
using Framework.Shared.Models.Token;
using Framework.Shared.Models.User;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;

namespace Framework.Shared.Data
{
    public class FrameworkDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<TokenModel> Tokens { get; set; }
        public DbSet<FileModel> Files { get; set; }
        public DbSet<TemplateModel> Templates { get; set; }
        public DbSet<SettingModel> Settings { get; set; }
        //public DbSet<CultureModel> Cultures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                FrameworkConfiguration.ConnectionString,
                x => x.MigrationsAssembly(FrameworkConfiguration.ExecutingAssemblyName)
                .EnableRetryOnFailure()
                .CommandTimeout(15)
                .MigrationsHistoryTable("MigrationsHistory", "framework")
                );

            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();
            optionsBuilder.LogTo(new StreamWriter("EnitityFramework-logs.txt", append: true).WriteLine);
            optionsBuilder.AddInterceptors(new CustomInterceptor());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("framework");
            modelBuilder.UseIdentityColumns();

        }
    }

    public class CustomInterceptor : Microsoft.EntityFrameworkCore.Diagnostics.IDbCommandInterceptor
    {
        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            // Wywoływane po wykonaniu operacji non-query
            Console.WriteLine("Zakończyłem zapytanie");
        }

        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            // Wywoływane przed wykonaniem operacji non-query
            Console.WriteLine("Rozpoczynam zapytanie");
        }

        // Inne metody interfejsu IDbCommandInterceptor
    }
}
