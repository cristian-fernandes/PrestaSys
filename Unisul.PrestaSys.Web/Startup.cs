using System;
using System.Globalization;
using System.Threading;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unisul.PrestaSys.Dominio.Helpers;
using Unisul.PrestaSys.Dominio.Servicos.Prestacoes;
using Unisul.PrestaSys.Dominio.Servicos.Usuarios;
using Unisul.PrestaSys.Entidades.Notificacoes;
using Unisul.PrestaSys.Entidades.PdfGeneration;
using Unisul.PrestaSys.Repositorio;
using Unisul.PrestaSys.Repositorio.Prestacoes;
using Unisul.PrestaSys.Repositorio.Usuarios;
using Unisul.PrestaSys.Web.Services;

namespace Unisul.PrestaSys.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var cultureInfo = new CultureInfo("pt-BR")
            {
                NumberFormat = { CurrencySymbol = "R$" }
            };

            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            var supportedCultures = new[]
            {
                new CultureInfo("pt-BR")
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("pt-BR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler("/Home/Error");

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Login}/{action=Index}/{id?}");
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAutoMapper();

            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = new PathString("/Login");
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
            });

            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.AuthorizeFolder("/");
                options.Conventions.AllowAnonymousToPage("/Login");
            });


            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.Configure<JsReportSettings>(Configuration.GetSection("JsReportSettings"));

            services.AddDbContext<PrestaSysDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("PrestacaoDb")));

            services.AddScoped<IPrestaSysDbContext>(provider => provider.GetService<PrestaSysDbContext>());
            services.AddTransient<IPrestacaoRepository, PrestacaoRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IPrestacaoService, PrestacaoService>();

            services.AddTransient<IViewRenderService, ViewRenderService>();
            services.AddTransient<IEmailHelper, EmailHelper>();
        }
    }
}
