## EFCore 新增 EF.Function

在EFCore 2.0开始，在使用时增加了 EF.Function方法，此方法对应数据库中的函数，在.Net5中会大次推广

比较通用的是 Like方法：

例子：

~~~ c#
using Microsoft.EntityFrameworkCore;
       public void GetUserinfo()
        {
            _dbContext.UserInfos.Where(c => EF.Functions.Like(c.UserName, "%风%")).ToList();
        }
~~~

其他使用方式目前未使用过，以后可以尝试：

基本是一些时间函数，与数据库中常用的函数功能相同

例子：

~~~ c#
using Microsoft.EntityFrameworkCore;
     
            EF.Functions.Contains();
            EF.Functions.DateDiffDay();
            EF.Functions.DateDiffHour();
            EF.Functions.DateDiffMinute();
            EF.Functions.DateDiffMonth();
            EF.Functions.DateDiffSecond();
            EF.Functions.DateDiffYear();
            EF.Functions.IsDate();
        
~~~

