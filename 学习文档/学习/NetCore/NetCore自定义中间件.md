### .NetCore 调用自定义中间件

`中间件是组装到应用管道中处理响应请求的软件`

管道运行：先执行Program 创建一个HostBuilder 容器，读取StartUP中的注入服务，读取初始化变量，进入Kastual浏览器，执行Configure 中间件。

.net Core 可以自定义中间件或使用内置的中间件，或引用第三方的中间件。

总之灵活配置就是.net Core 的优点之一。

.net Core 提供了几种调用中间件的方法：

中间件执行顺序很重要：

~~~c#
   app.Use(async (context, next) =>
	 {
				await context.Response.WriteAsync("进入第一个委托 执行下一个委托之前\r\n");
				//调用管道中的下一个委托
		        await next.Invoke();
		        await context.Response.WriteAsync("结束第一个委托 执行下一个委托之后\r\n");
	 });
   app.Run(async context =>
	  {
		        await context.Response.WriteAsync("进入第二个委托\r\n");
				await context.Response.WriteAsync("Hello from 2nd delegate.\r\n");
		        await context.Response.WriteAsync("结束第二个委托\r\n");
	  });

//返回的结果：
       进入第一个委托 执行下一个委托之前
       进入第二个委托
       Hello from 2nd delegate
       结束第二个委托
       结束第一个委托 执行下一个委托之后
~~~

![668104-20171031100753449-11207087](C:\Users\Administrator\Desktop\668104-20171031100753449-11207087.png)

`Startup.Configure`方法（如下所示）添加了以下中间件组件(**推荐执行顺序**)：

1. 异常/错误处理
2. 静态文件服务
3. 身份认证
4. MVC

~~~c#
public void Configure(IApplicationBuilder app)
{
    app.UseExceptionHandler("/Home/Error"); // Call first to catch exceptions
                                            // thrown in the following middleware.

    app.UseStaticFiles();                   // Return static files and end pipeline.

    app.UseAuthentication();               // Authenticate before you access
                                           					// secure resources.

    app.UseMvcWithDefaultRoute();          // Add MVC to the request pipeline.
}
~~~



1. Run   

​       Run方法的定义是加在管道的结尾，也就是说Run方法调用中间件后，就结束了不再执行下一个中间件了。

~~~c#
            app.Run(async context => {
                await context.Response.WriteAsync("最后一个啊");//只执行这一个
            });
            app.Run(async context => {
                await context.Response.WriteAsync("真的是最后一个啊");//这个不执行
            });
~~~

2. Use

   Use方法的定义是调用自定义中间件，它有一个**next.Invoke()** 方法，再不调用此方法时，与**Run** 方法是没有区别的，调用**next.Invoke()** 方法时表明，执行完此中间件后继续执行下一个中间件。

   ~~~ c#
       app.Use(async (context, next) =>
               {
                   await context.Response.WriteAsync("<p>假如这个是最后一个啊</p>");
                   await next.Invoke();//不加这个，不会执行下一个中间件
   
               });
   ~~~

3. app.UseMiddleware<>()

   UseMiddleware方法是自己创建class，在上面写自己的中间件内容，与**Use** 大体相同。

   此方法还有一种不暴露出来的方式（在单独的一个类中封装），通过**IApplicationBuilder ** 扩展方法封装，在StartUp暴露。*代码就不贴出来了，想用的时候再搜吧！* 

   ~~~c#
      //在startup中调用此方法
      app.UseMiddleware<CusMiddleware>();
       
       /// <summary>
       /// 实现自定义的中间件
       /// </summary>
       public class Middleware
       {
           private readonly RequestDelegate _next;
           public Middleware(RequestDelegate next)
           {
               _next = next;
           }
   
           public async Task Invoke(HttpContext context)
           {
               await _next(context);
               await context.Response.WriteAsync("<p>Response1</p>");//响应出去时逻辑，为了验证顺序性，输出一句话
           }
       }
   
   ~~~

4. Map

   Map与以上的例子不同，Map是将中间件创建管道分支，增加到管道中

   ~~~C#
      //Map中的参数 1：浏览器访问地址，2：要执行的中间件
      //localhost:5000/home/mapTest
   app.Map("/mapTest", HandleMap);
   
      //也可以匹配多个路径片段
   app.Map("/mapTest1/mapTest2", HandleMap);
   
    private static void HandleMap(IApplicationBuilder app)
      {
          app.Run(async context =>
          {
            await context.Response.WriteAsync("Hello ,that is Handle Map ");
          });
       }
   ~~~

   

5. MapThen

   MapThen 在满足条件的情况下执行此中间件，比如设置谓词判断

   ~~~c#
       app.MapWhen(context =>
        { 
          //请求的链接中key包含 q 则执行下面的中间件 localhost:5000/home/index?id=6
          return context.Request.Query.ContainsKey("Id"); 
        }, HandleQuery);
        
          private static void HandleQuery(IApplicationBuilder app)
           {
               app.Run(async context =>
               {
                 await context.Response.WriteAsync("  Hello ,this is Handle Query ");
               });
           }
        
   ~~~

6.  .NetCore 自带中间件

   ASP.NET Core附带以下中间件组件：

   | 中间件                   | 描述                                 |
   | ------------------------ | ------------------------------------ |
   | Authentication           | 提供身份验证支持                     |
   | CORS                     | 配置跨域资源共享                     |
   | Response Caching         | 提供缓存响应支持                     |
   | Response Compression     | 提供响应压缩支持                     |
   | Routing                  | 定义和约束请求路由                   |
   | Session                  | 提供用户会话管理                     |
   | Static Files             | 为静态文件和目录浏览提供服务提供支持 |
   | URL Rewriting Middleware | 用于重写 Url，并将请求重定向的支持   |

​       