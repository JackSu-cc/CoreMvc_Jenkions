using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IService.IUserService;
using Application.Service.UserService;
using Common.BaseInterfaces.IBaseRepository;
using Common.BaseInterfaces.IBaseRepository.IRepository;
using Common.CommonHellper.Ext;
using Domain.IRepository;
using Infrastruct.Context;
using Infrastruct.Repository.BaseRepository;
using Infrastruct.Repository.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Common.CommonHellper;
using Swashbuckle.AspNetCore.Filters;
using MediatR;
using Domain.Cmds;
using Domain.CmdHandler;
using Common.IService;
using Common.Service;
using Common.Notice;
using Domain.Events;
using Domain.EventHandler;
using Common.Consul;
using ClientDependency.Core;
using IApplicationLifetime = Microsoft.AspNetCore.Hosting.IApplicationLifetime;

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
            services.AddControllers();//.SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
            //添加数据库连接
            services.AddDbContext<CoreDemoDBContext>(o =>
            {
                o.UseSqlServer(Configuration.GetSection("ConnectionStrings:Default").Value);
            });



            #region 添加JWT

            services.AddOptions();
            services.Configure<JwtSettings>(Configuration.GetSection("JwtToken"));

            JwtSettings jwtSettings = new JwtSettings();
            Configuration.Bind("JwtToken", jwtSettings);
            
            services.AddAuthentication(opertion =>
            {
                opertion.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opertion.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(c =>
            {
                //配置JWT参数
                c.TokenValidationParameters = new TokenValidationParameters
                {
                    //是否验证发行人
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings.Issuer,//发行人
                                                     //是否验证受众人
                    ValidateAudience = true,
                    ValidAudience = jwtSettings.Audience,//受众人
                                                         //是否验证密钥
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.SecretKey)),

                    ValidateLifetime = true, //验证生命周期
                    RequireExpirationTime = true, //过期时间
                };
                c.Events = new JwtBearerEvents()
                {
                    OnChallenge = context =>
                    {
                        context.HandleResponse();
                        var payload = JsonConvert.SerializeObject(new CusResult
                        {
                            code = 401,
                            msg = "很抱歉，您无权访问该接口！",
                            data = null
                        });
                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = 200;
                        context.Response.WriteAsync(payload);
                        return Task.FromResult(0);
                    }
                };
            });
            #endregion

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

                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                // 很重要！这里配置安全校验，和之前的版本不一样
                c.OperationFilter<SecurityRequirementsOperationFilter>();

                // 开启 oauth2 安全描述，必须是 oauth2 这个单词
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
            });
            #endregion

            //注入缓存
            services.AddSingleton<IMemoryCache, MemoryCache>();

            //services.AddTransient<>
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            //注入仓储
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IEFRepository<>), typeof(EFRepository<>));

            #region 增加MediatR

            //增加MediatR
            services.AddMediatR(typeof(Startup));
            services.AddScoped<IMediatorService, MediatorService>();
            services.AddScoped<INotificationHandler<Notification>, Noticehandler>();
            #endregion

            //抛送命令： Mediatr  Request/Response
            services.AddScoped<IRequestHandler<AddUserCommand, Unit>, UserCmdHandler>();
            //抛送事件： Notification 
            services.AddScoped<INotificationHandler<InitUserRoleEvent>, InitUserRoleEventHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

          
            
            app.UseRouting();
            //1.先开启认证
            app.UseAuthentication();
            //2.再开启授权
            app.UseAuthorization();

   


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            #region 添加Swagger中间件

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1"); });
            #endregion
        }
    }
}
