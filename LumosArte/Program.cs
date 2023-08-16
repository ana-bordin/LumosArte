using API;
using LumosArte.Helper;
using LumosArte.Repositories;
using LumosArte.ViewComponents;
using Microsoft.EntityFrameworkCore;

namespace LumosArte
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddControllersWithViews().AddRazorOptions(options =>
            //{options.ViewLocationFormats.Add("/{0}.cshtml");});

            builder.Services.AddDbContext<LumosDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), opt=>opt.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)));
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // Injeção de dependencia
            builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<IAjudaRepositorio, AjudaRepositorio>();
            builder.Services.AddScoped<ISessao,Sessao>();
            builder.Services.AddSession(x => {
                x.Cookie.HttpOnly = true;
                x.Cookie.IsEssential = true;

            });

            builder.Services.AddTransient<CategoriaView>();
            builder.Services.AddTransient<ProdutoView>();
            builder.Services.AddTransient<MenuView>();
            builder.Services.AddTransient<AssuntoView>(); 
            builder.Services.AddTransient<ArtistaView>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Produto}/{action=Index}/{id?}/{searchTerm?}");

            app.Run();
        }
    }
}