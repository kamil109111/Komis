using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Komis
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // dodanie obsługi strony ExceptionPage, komponent używany podczas pisania aplikacji
            // zwraca błędy w aplikacji
            app.UseDeveloperExceptionPage();

            // komponent który zwraca status żądania np. 400, 500
            app.UseStatusCodePages();

            // podłączenie obsługi plików statycznych np. obrazy, pliki js i inne
            app.UseStaticFiles();

            // używamy MVC z domyślnym routingiem
            app.UseMvcWithDefaultRoute();
        }
    }
}
