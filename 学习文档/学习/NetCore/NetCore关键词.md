### Host

​        通用型主机，在启动.net Core 项目时创建，主机作为一个对象封装了应用资源、应用程序启动和生存周期管理。主要功能包括：加载配置项、创建托管环境、上下文、依赖注入。

封装的对象有：

- 依赖注入 (DI)
- Logging
- Configuration
- 托管服务：IHostedService 实现

主机启动时会创建一个 Http服务器创建 web服务，用来监听响应请求--------`Kestrel`







## CreateHostBuilder

### CreateDefaultBuilder

​       在CreateHostBuilder方法中实现的第一个方法就是CreateDefaultBuilder，此方法的目的为构建一个HostBuilder。

​       在构建HostBuilder对象时所作的配置：

- 将内容根目录（contentRootPath）设置为由 GetCurrentDirectory 返回的路径。
- 通过以下源加载主机配置
  - 环境变量（DOTNET_前缀）配置
  - 命令行参数配置
-    通过以下对象加载应用配置
  - appsettings.json 
  - appsettings.{Environment}.json
  - 密钥管理器 当应用在 Development 环境中运行时
  - 环境变量
  - 命令行参数
-    添加日志记录提供程序

- - 控制台
  - 调试
  - EventSource
  - EventLog（ Windows环境下）

- 当环境为“开发”时，启用范围验证和依赖关系验证。

###  ConfigureWebHostDefaults

* 通过*GenericWebHostBuilder*（是IWebHostBuilder的实现） 对之前构建的HostBuilder增加Asp.NetCore 的运行时设置。
* 对注入的IWebHostBuilder调用ConfigureWebDefaults(WebHostBuilder)启动各类设置：    

- * 前缀为 ASPNETCORE_ 的环境变量加载主机配置。
  * 将[ Kestrel作为默认的Web服务器](https://docs.microsoft.com/zh-cn/aspnet/core/fundamentals/servers/kestrel?view=aspnetcore-3.1&WT.mc_id=DT-MVP-5003918)
  * 添加HostFiltering中间件（[主机筛选中间件](https://docs.microsoft.com/zh-cn/aspnet/core/fundamentals/servers/kestrel?view=aspnetcore-3.1#host-filtering&WT.mc_id=DT-MVP-5003918)）
  * 如果ASPNETCORE_FORWARDEDHEADERS_ENABLED=true，添加[转接头中间件ForwardedHeaders](https://docs.microsoft.com/zh-cn/aspnet/core/host-and-deploy/proxy-load-balancer?view=aspnetcore-3.1#forwarded-headers&WT.mc_id=DT-MVP-5003918) 
  * [启用IIS集成]
- 同时执行webBuilder.UseStartup<Startup>()



## Build()



在CreateHostBuilder 返回IHostBuilder之后，进行Build()，Build的过程主要完成：



- BuildHostConfiguration： 构造配置系统，初始化 IConfiguration _hostConfiguration;
- CreateHostingEnvironment：构建主机HostingEnvironment环境信息，包含ApplicationName、EnvironmentName、ContentRootPath等
- CreateHostBuilderContext：创建主机Build上下文HostBuilderContext，上下文中包含：HostingEnvironment和Configuration
- BuildAppConfiguration：构建应用程序配置
- CreateServiceProvider：创建依赖注入服务提供程序， 即依赖注入容器



## Run()

Run()方法执行的也是RunAsync()这个异步方法，内部执行的是启动DI依赖注入所有的服务。



## Kestrel

是一款基于中间件处理tcp连接的服务器，内置http、websocket、Singir解析中间件。

