using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models.Blog.Autor;
using Blog.Models.Blog.Categoria;
using Blog.Models.Blog.Etiqueta;
using Blog.Models.Blog.Postagem;
using Blog.Models.Blog.Postagem.Classificacao;
using Blog.Models.Blog.Postagem.Comentario;
using Blog.Models.Blog.Postagem.Revisao;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Blog
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
            using (var databaseContext = new DatabaseContext())
            {
                databaseContext.Database.EnsureCreated();
            }

            // Adicionar o serviço do banco de dados
            services.AddDbContext<DatabaseContext>();

            // Adicionar os serviços de ORM das entidades do domínio
            services.AddTransient<CategoriaOrmService>();
            services.AddTransient<PostagemOrmService>();
            services.AddTransient<AutorOrmService>();
            services.AddTransient<EtiquetaOrmService>();
            services.AddTransient<ClassificacaoOrmService>();
            services.AddTransient<ComentarioOrmService>();
            services.AddTransient<RevisaoOrmService>();


            // Adicionar os serviços que possibilitam o funcionamento dos controllers e das views
            services.AddControllersWithViews();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //Configuração de rotas
            app.UseEndpoints(endpoints =>
            {
                /*
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                */

                //rotas da área comum
                endpoints.MapControllerRoute(
                    //passa um nome
                    name: "comum",
                    //passa um padrão de url
                    pattern: "/",
                    //seta os dados que serão usados internamente para achar o controler e a action
                    defaults: new { controller = "Home", action = "Index"});

                //rotas da áea administrativa
                    //rota categorias
                endpoints.MapControllerRoute(
                    name: "admin.categorias",
                    pattern: "admin/categorias/{action}/{id?}",
                    defaults: new { controller = "AdminCategorias", action = "Listar" });

                    //rota autores
                endpoints.MapControllerRoute(
                   name: "admin.autores",
                   pattern: "admin/autores/{action}/{id?}",
                   defaults: new { controller = "AdminAutores", action = "Listar" });

            });
        }
    }
}
