using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ICIMS.Configuration;
using ICIMS.Web;

namespace ICIMS.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ICIMSDbContextFactory : IDesignTimeDbContextFactory<ICIMSDbContext>
    {
        public ICIMSDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ICIMSDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ICIMSDbContextConfigurer.Configure(builder, configuration.GetConnectionString(ICIMSConsts.ConnectionStringName));

            return new ICIMSDbContext(builder.Options);
        }
    }
}
