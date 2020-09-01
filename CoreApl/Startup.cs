using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.IService.IUserService;
using Application.Service.UserService;
using Common.BaseInterfaces.IBaseRepository;
using Common.BaseInterfaces.IBaseRepository.IRepository;
using Domain.IRepository;
using Infrastruct.Context;
using Infrastruct.Repository.BaseRepository;
using Infrastruct.Repository.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoreApl
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //添加controller服务(webapi)
            services.AddControllers();
            //添加数据库连接
            services.AddDbContext<CoreDemoDBContext>(o =>
            {
                o.UseSqlServer(Configuration.GetSection("ConnectionStrings:Default").Value);
            });

            //注入缓存
            services.AddSingleton<IMemoryCache, MemoryCache>();

            //services.AddTransient<>
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            //注入仓储
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IEFRepository<>), typeof(EFRepository<>));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

          
        }
    }
}
