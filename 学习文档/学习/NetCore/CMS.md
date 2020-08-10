Orchard Core 是Orchard CMS的ASP.NET Core版本。

Orchard Core是全新一代的ASP.NET Core CMS。

官方文档介绍：http://orchardcore.readthedocs.io/en/latest/
GitHub: https://github.com/OrchardCMS/OrchardCore

下面快速开始搭建CMS

## 新建项目

打开VS2017 新建一个CMSWeb的ASP.NET Core Web应用程序

 ![img](https://images2017.cnblogs.com/blog/443844/201711/443844-20171122132123774-1744495249.png)

然后选择空模板

![img](https://images2017.cnblogs.com/blog/443844/201711/443844-20171122132155071-514774604.png) 

### 安装OrchardCore包

NuGet包命令 目前预览版需加 -Pre

> Install-Package OrchardCore.Application.Cms.Targets -Pre

或者在NuGet搜索 OrchardCore.Application.Cms.Targets

![img](https://images2017.cnblogs.com/blog/443844/201711/443844-20171122132220586-1600332313.png)

 

## 项目开发

打开Startup.cs ,在ConfigureServices加入

```
services.AddOrchardCms(); 
```

然后删除Configure 中的

```
app.Run(async (context) =>
{
    await context.Response.WriteAsync("Hello World!");
}); 
```

加入

```
app.UseModules(); 
```

最终如下：

[![复制代码](https://common.cnblogs.com/images/copycode.gif)](javascript:void(0);)

```
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOrchardCms();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseModules();
        }
    }
```

[![复制代码](https://common.cnblogs.com/images/copycode.gif)](javascript:void(0);)

然后运行程序，打开浏览会看到初始化安装界面。输入对应信息，然后完成安装。

![img](https://images2017.cnblogs.com/blog/443844/201711/443844-20171122132512555-2087507012.png)

 


注意密码必须包含大小写数字和字符才能成功提交。如上图中出现红色是不行的。

安装好后配置一下，最终如下：

![img](https://images2017.cnblogs.com/blog/443844/201711/443844-20171122132537586-1510386562.png)

 

后台为/Admin ，可以进入查看相关设置。

Orchard Core Framework：ASP.NET Core 模块化，多租户框架。

《[ASP.NET Core跨平台开发从入门到实战](https://item.jd.com/12063817.html)》 [京东](https://item.jd.com/12063817.html) [淘宝](https://s.taobao.com/search?q=asp+net+core跨平台开发从入门到实战) [亚马逊](https://www.amazon.cn/ASP-NET-Core跨平台开发从入门到实战-张剑桥/dp/B06Y488FJ4/?ie=UTF8&keywords=asp.net+core) [当当](http://product.dangdang.com/25060131.html)

博客示例代码GitHub：https://github.com/linezero/Blog