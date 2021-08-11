using EFCoreRef.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreRef
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var EFCoreRefConnectionString = "Data Source=efcoreref.db";

            services.AddDbContext<EFCoreRefContext>(builder =>
                builder.UseSqlite(EFCoreRefConnectionString));
        }
    }

    
}
