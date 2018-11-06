using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ICIMS.EntityFrameworkCore
{
    public static class ICIMSDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ICIMSDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ICIMSDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
