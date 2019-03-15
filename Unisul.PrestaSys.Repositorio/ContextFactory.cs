using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Unisul.PrestaSys.Repositorio
{
    public class ContextFactory : IDesignTimeDbContextFactory<PrestaSysDbContext>
    {
        public PrestaSysDbContext CreateDbContext()
        {
            return CreateDbContext(null);
        }

        public PrestaSysDbContext CreateDbContext(string[] args)
        {
            var builderConfiguration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json");
            var configuration = builderConfiguration.Build();
            var connectionString = configuration.GetConnectionString("PrestacaoDb");

            var builder = new DbContextOptionsBuilder<PrestaSysDbContext>();
            builder.UseSqlServer(connectionString);

            return new PrestaSysDbContext(builder.Options);
        }
    }
}
