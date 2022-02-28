using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pviturro.EcommerceAPI.Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EcommerceContext>
    {
        public EcommerceContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../Pviturro.EcommerceAPI/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<EcommerceContext>();
            var connectionString = configuration.GetConnectionString("DatabaseConnection");
            builder.UseSqlite(connectionString);
            return new EcommerceContext(builder.Options);
        }
    }
}
