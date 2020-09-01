### Swagger 3.X

1. ####安装Swagger

   #####使用nuget安装：Swashbuckle.AspNetCore

2. ####基本配置

   1. #####设置项目属性

   ![image-20200901152504475](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200901152504475.png)

2. #####服务注册

   ~~~ c#
    //配置Swagger
    services.AddSwaggerGen(c =>
    {
        var version = "v1";
        c.SwaggerDoc(version, new OpenApiInfo
        {
            Title = $"{Configuration.GetSection("BasicSettings:apiName").Value} CoreAPI接口文档——dotnetcore 3.1",//编辑标题
            Version = version,//版本号
            Description = $"{Configuration.GetSection("BasicSettings:apiName").Value} HTTP API V1",//编辑描述
            Contact = new OpenApiContact { Name = Configuration.GetSection("BasicSettings:apiName").Value, Email = "929013002@qq.com" },//编辑联系方式
            License = new OpenApiLicense { Name = Configuration.GetSection("BasicSettings:apiName").Value }//编辑许可证
        });
        c.OrderActionsBy(o => o.RelativePath);//排列顺序
                                              
        var xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CoreApl.xml");// 配置接口文档文件路径
        c.IncludeXmlComments(xmlPath, true); // 把接口文档的路径配置进去。第二个参数表示的是是否开启包含对Controller的注释容纳
    });
   
   ~~~
   
4. #####添加Swagger中间件

   ~~~c#
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseSwagger();
      app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1"); });
    }
   ~~~

5. #####修改launchSettings.json 设置默认进入Swagger页面，或从项目属性中配置

![image-20200901153423456](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200901153423456.png)

6. #####书写注释

   ![image-20200901153717404](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200901153717404.png)



####End :生成效果

![image-20200901154003562](C:\Users\Administrator\AppData\Roaming\Typora\typora-user-images\image-20200901154003562.png)

