using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

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

            #region 配置Swagger服务 
            //配置Swagger
            services.AddSwaggerGen(c =>
            {
                var version = "v1";
                c.SwaggerDoc(version, new OpenApiInfo
                {
                    Title = $"{Configuration.GetSection("BasicSettings:apiName").Value} CoreAPI接口文档——dotnetcore 3.1",//编辑标题
                    Version = version,//版本号
                    Description = $"{Configuration.GetSection("BasicSettings:apiName").Value} HTTP API V1",//编辑描述
                    Contact = new OpenApiContact { Name = $"{ Configuration.GetSection("BasicSettings:apiName").Value }-点我给管理员发邮件", Email = "929013002@qq.com" },//编辑联系方式
                    License = new OpenApiLicense { Name = Configuration.GetSection("BasicSettings:apiName").Value }//编辑许可证
                });
                c.OrderActionsBy(o => o.RelativePath);//排列顺序
                                                      
                var xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CoreApl.xml");// 配置接口文档文件路径
                c.IncludeXmlComments(xmlPath, true); // 把接口文档的路径配置进去。第二个参数表示的是是否开启包含对Controller的注释容纳
            });
            #endregion


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            #region 添加Swagger中间件

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1"); });
            #endregion
        }
    }
}
