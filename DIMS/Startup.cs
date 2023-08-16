using DIMS.DIMSDataContext;
using DIMS.Entities.Account;
using DIMS.Helpers;
using DIMS.IRepositories;
using DIMS.IRepositories.ILanguageRepository;
using DIMS.Repositories;
using DIMS.Repositories.LanguageRepository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS
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
            //Localization
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<ILocalizationService, LocalizationService>();

            services.AddRazorPages();

            services.AddDbContext<DIMSDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUsers, IdentityRole>()
                .AddEntityFrameworkStores<DIMSDbContext>();
            services.AddLocalization();

            services.AddControllersWithViews()
                .AddViewLocalization();

            //var serviceProvider = services.BuildServiceProvider();
            //var languageService = serviceProvider.GetRequiredService<ILanguageService>();
            //var languages = languageService.GetLanguages();
            //var cultures = languages.Select(x => new CultureInfo(x.Culture)).ToArray();

            services
                .AddMvc()
                .AddJsonOptions(option => option.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie
            //    (options =>
            //    {
            //        options.LoginPath = "/";
            //        options.LogoutPath = "/logout";
            //        options.AccessDeniedPath = "/Login/AccessDenied";
            //    });

            services.AddResponseCompression();
            services.Configure<GzipCompressionProviderOptions>
            (options =>
            {
                options.Level = CompressionLevel.Fastest;
            });
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<IZoneRepository, ZoneRepository>();
            services.AddScoped<IWoredaRepository, WoredaRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ITitleRepository, TitleRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<IDisabilityRepository, DisabilityRepository>();
            services.AddScoped<IEducationTypeRepository, EducationTypeRepository>();
            services.AddScoped<IEducationLevelRepository, EducationLevelRepository>();
            services.AddScoped<IEnterpriseLevelRepository, EnterpriseLevelRepository>();
            services.AddScoped<IEnterpriseStatusRepository, EnterpriseStatusRepository>();
            services.AddScoped<IGroupTypeRepository, GroupTypeRepository>();
            services.AddScoped<IMemberTypeRepository, MemberTypeRepository>();
            services.AddScoped<IPromotionLevelRepository, PromotionLevelRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IBranchItemRepository, BranchItemRepository>();
            services.AddScoped<ICapitalSourceRepository, CapitalSourceRepository>();
            services.AddScoped<IEnterpriseRepository, EnterpriseRepository>();
            services.AddScoped<IEnterpriseAddressInfoRepository, EnterpriseAddressInfoRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IMemberAddressInfoRepository, MemberAddressInfoRepository>();
            services.AddScoped<IEducationInformationRepository, EducationInformationRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUsers>, ApplicationUserClaimsPrincipalFactory>();


            //services.Configure<RequestLocalizationOptions>(options =>
            //{
            //    var englishCulture = cultures.FirstOrDefault(x => x.Name == "en-US");
            //    options.DefaultRequestCulture = new RequestCulture(englishCulture?.Name ?? "en-US");

            //    options.SupportedCultures = cultures;
            //    options.SupportedUICultures = cultures;
            //});
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
                app.UseExceptionHandler("/Account/Login");
                // app.UseHsts();

            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });

        }
    }
}
