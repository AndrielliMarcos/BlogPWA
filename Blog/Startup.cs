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
using Blog.Models.ControleDeAcesso;
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
            

            //Adicionar o servi�o do mecanismo  de controle de acesso
            services.AddIdentity<Usuario, Papel>(options =>
            {
                //valida��es do usu�rio
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 6;

            }).AddEntityFrameworkStores<DatabaseContext>()
                .AddErrorDescriber<DescritorDeErros>();

            // Configurar o mecanismo de controle de acesso
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/acesso/login";
            });

            // Adicionar o servi�o do controle de acesso
            services.AddTransient<ControleDeAcessoService>();

            // Adicionar o servi�o do banco de dados
            services.AddDbContext<DatabaseContext>();

            // Adicionar os servi�os de ORM das entidades do dom�nio
            services.AddTransient<CategoriaOrmService>();
            services.AddTransient<PostagemOrmService>();
            services.AddTransient<AutorOrmService>();
            services.AddTransient<EtiquetaOrmService>();
            services.AddTransient<ClassificacaoOrmService>();
            services.AddTransient<ComentarioOrmService>();
            services.AddTransient<RevisaoOrmService>();


            // Adicionar os servi�os que possibilitam o funcionamento dos controllers e das views
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

            //Configura��o de rotas
            app.UseRouting();

            app.UseAuthentication(); //saber se o usu�rio se identificou
            app.UseAuthorization(); //se o usu�rio tem permiss�o para acessar algum recurso

            
            app.UseEndpoints(endpoints =>
            {
                /*
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                */

                //rotas da �rea comum
                endpoints.MapControllerRoute(
                    //passa um nome
                    name: "comum",
                    //passa um padr�o de url
                    pattern: "/",
                    //seta os dados que ser�o usados internamente para achar o controler e a action
                    defaults: new { controller = "Home", action = "Index"});

                // Rotas do Controle de Acesso
                endpoints.MapControllerRoute(
                    name: "controleDeAcesso",
                    pattern: "acesso/{action}",
                    defaults: new { controller = "ControleDeAcesso", action = "Login" }
                );

                //rotas da �rea administrativa
                   //rota principal do administrador
                endpoints.MapControllerRoute(
                   name: "admin",
                   pattern: "admin",
                   defaults: new { controller = "Admin", action = "Painel" });

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

                    //rota etiquetas
                endpoints.MapControllerRoute(
                   name: "admin.etiquetas",
                   pattern: "admin/etiquetas/{action}/{id?}",
                   defaults: new { controller = "AdminEtiquetas", action = "Listar" });

                    //rota postagens
                endpoints.MapControllerRoute(
                   name: "admin.postagens",
                   pattern: "admin/postagens/{action}/{id?}",
                   defaults: new { controller = "AdminPostagens", action = "Listar" });

            });
        }
    }
}
