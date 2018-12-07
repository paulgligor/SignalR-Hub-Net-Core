using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SignlarR.Hubs;

namespace SignalR.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Cors
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins("https://example-project-signalr-client.azurewebsites.net")
                    .AllowCredentials();
            }));

            // Application services.
            services.AddScoped<IMessagingHub, MessagingHub>();

            // SignalR
            services.AddSignalR(options =>
            {
                options.EnableDetailedErrors = true;
            });
            //services.AddSignalR();

            // Mvc
            services.AddMvc();
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseHsts();
            }
            app.UseCors("CorsPolicy");
            //app.UseHttpsRedirection();
            //app.UseWebSockets();
            app.UseSignalR(routes =>
            {
                //slashes must be consistent, no double slashes
                //and hub URLs should always start with a slash
                routes.MapHub<MessagingHub>("/hubs/messaging");
            });
            app.UseMvc();
        }
    }
}
