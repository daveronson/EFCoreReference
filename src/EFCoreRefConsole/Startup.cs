using EFCoreRef.DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace EFCoreRef
{
    public class Startup
    {
        private readonly IHostingEnvironment hostingEnvironment;
        public Startup(IHostingEnvironment env)
        {
            hostingEnvironment = env;
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                //builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.

            var EFCoreRefConnectionString = "Data Source=efcoreref.db";

            services.AddDbContext<EFCoreRefContext>(builder =>
                builder.UseSqlite(EFCoreRefConnectionString));

        }
    }
}
