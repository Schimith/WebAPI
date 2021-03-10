using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.OData;
using WebAPI.Models;
using WebAPI.Services;
using WebAPI.IServices;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI
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
            //WebPage Default
            services.AddRazorPages();
            
            //API
            services.AddControllers();
            services.AddHttpClient();
            services.AddDbContext<LOJAContext>(options => 
                     options.UseSqlServer(Configuration["DbConnection"]));
            
            //Clientes
            services.AddTransient<IClienteService, ClienteService>();

            //Produtos
            services.AddTransient<IProdutoService, ProdutoService>();

            //Pedidos
            services.AddTransient<IPedidoService, PedidoService>();

            //Pedidos por clientes
            services.AddTransient<IClientePedidoService, ClientePedidoService>();

            //Pedidoss por produtos
            services.AddTransient<IPedidoProdutoService, PedidoProdutoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //WebPage Default
                endpoints.MapRazorPages();
                //API
                endpoints.MapControllers();
            });            
        }
    }
}