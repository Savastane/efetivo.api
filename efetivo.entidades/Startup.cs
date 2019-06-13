namespace efetivo.api
{

    using System.Configuration;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using efetivo.entidades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;


    public class Startup
    {



        public void ConfigureServices(IServiceCollection services)
        {   
            
            services.AddEntityFrameworkNpgsql()
            .AddDbContext<ResumoContext>(options => options.UseNpgsql(ConfigurationManager.AppSettings["dbefetivo"]));
        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
           
        }

    }
}
