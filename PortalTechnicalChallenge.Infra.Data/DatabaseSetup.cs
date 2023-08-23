using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PortalTechnicalChallenge.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalTechnicalChallenge.Infra.Data
{
    /// <summary>
    /// setup database - chamado na statup
    /// </summary>
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            

            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<PortalTechnicalChallengeContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        }




    }
}
