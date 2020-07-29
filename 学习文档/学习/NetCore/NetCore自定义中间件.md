### .NetCore 调用自定义中间件

.net Core 可以自定义中间件或使用内置的中间件，或引用第三方的中间件。

总之灵活配置就是.net Core 的优点之一。

.net Core 提供了几种调用中间件的方法：

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
   app.Map("/mapTest", HandleMap);
   
    private static void HandleMap(IApplicationBuilder app)
      {
          app.Run(async context =>
          {
            await context.Response.WriteAsync("Hello ,that is Handle Map ");
          });
       }
   ~~~

   

5. MapThen

   MapThen 在满足条件的情况下执行此中间件

   ~~~c#
       app.MapWhen(context =>
        { 
          //请求的链接中key包含 q 则执行下面的中间件
          return context.Request.Query.ContainsKey("q"); 
        }, HandleQuery);
        
          private static void HandleQuery(IApplicationBuilder app)
           {
               app.Run(async context =>
               {
                 await context.Response.WriteAsync("  Hello ,this is Handle Query ");
               });
           }
        
   ~~~

   

