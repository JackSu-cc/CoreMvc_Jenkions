## Entity Framework Core Like 查询揭秘

在Entity Framework Core 2.0中增加一个很酷的功能：`EF.Functions.Like()`，最终解析为SQL中的`Like`语句，以便于在 LINQ 查询中直接调用。

不过Entity Framework 中默认提供了`StartsWith`、`Contains`和`EndsWith`方法用于解决模糊查询，那么为什么还要提供`EF.Functions.Like`，今天我们来重点说说它们之间的区别。



## EF.Functions.Like 使用示例

我们来看一个`EF.Functions.Like()`查询示例，查询 *CategoryName* 字段中包括字符串 **“t”** 的数据，传递的参数是 **“%t%”**：

```csharp
        [Fact]
        public void Like()
        {
            using (var dataContext = new SampleDbContext()) {

               var result= dataContext.Categories.Where(item => EF.Functions.Like(item.CategoryName, "%t%")).ToList();
           
                foreach (var item in result) {
                    _testOutputHelper.WriteLine(item.CategoryName);
                }
            }
        }
```

> 提示：在做一些示例演示时，个人喜欢会用 Xunit + Resharper，这样可以直接运行对应的示例，并且也可以直接输出对应的结果。

我们来看一下运行的结果：

![EF.Functions.Like](https://images2017.cnblogs.com/blog/162090/201709/162090-20170912153711297-2044070549.png)

查询的结果包含两条数据，这与我们预期结果一致。

## 字符串匹配模式

在这里，我暂且将`StartsWith`、`Contains`和`EndsWith`方法称之为**字符串匹配模式**。

您肯定在Entity Framework中使用过这些方式，我们还是简单说明一下这三个方法的作用：

- `StartsWith`：表示字符串的开头是否与指定的字符串匹配；
- `Contains`：表示指定的子串是否出现在此字符串中；
- `EndsWith`：表示字符串的结尾是否与指定的字符串匹配；

我们可以通过`Contains`方法实现与前一个示例一致的功能：

```csharp
        [Fact]
        public void Contains()
        {
            using (var dataContext = new SampleDbContext())
            {
                var result = dataContext.Categories.Where(item => item.CategoryName.Contains("t")).ToList();

                foreach (var item in result)
                {
                    _testOutputHelper.WriteLine(item.CategoryName);
                }

            }
        }
```

我们在`Contains`方法转入参数**“t”** ，运行的结果如下：

![EF Contains](https://images2017.cnblogs.com/blog/162090/201709/162090-20170912153650110-770972185.png)

运行结果与 `Like` 函数示例的结果是一致的。

在这里我只列举了`Contains`的示例，`StartsWith`和`EndsWith`的功能非常相似，我就不重复列举了。

这两个示例的运行结果是一致的，那么微软为什么要提供`EF.Functions.Like()`方法呢？

## 通配符模糊查询

我们知道在 T-SQL 语句中 *Like* 关键字支持 **通配符** ，下面简单介绍支持的通配符：

| 通配符      | 说明                                                      | 示例                                                         |
| ----------- | --------------------------------------------------------- | ------------------------------------------------------------ |
| %           | 包含零个或多个字符的任意字符串。                          | WHERE title LIKE '%computer%' 将查找在书名中任意位置包含单词 "computer" 的所有书名。 |
| _（下划线） | 任何单个字符。                                            | WHERE au_fname LIKE '_ean' 将查找以 ean 结尾的所有 4 个字母的名字（Dean、Sean 等）。 |
| [ ]         | 指定范围 ([a-f]) 或集合 ([abcdef]) 中的任何单个字符。     | WHERE au_lname LIKE '[C-P]arsen' 将查找以 arsen 结尾并且以介于 C 与 P 之间的任何单个字符开始的作者姓氏， 例如 Carsen、Larsen、Karsen 等。 |
| [^]         | 不属于指定范围 ([a-f]) 或集合 ([abcdef]) 的任何单个字符。 | WHERE au_lname LIKE 'de[^l]%' 将查找以 de 开始并且其后的字母不为 l 的所有作者的姓氏。 |

关于 *Like* 和通配符更多的知识请直接到MSDN中了解，链接地址：https://msdn.microsoft.com/zh-cn/library/ms179859(v=sql.110).aspx。

我们的将查询关键字由 **“t”** 改为 **“[a-c]”**，再来看上面两个示例分别运行的结果：

**EF.Functions.Like** 查询示例：

![EF.Functions.Like](https://images2017.cnblogs.com/blog/162090/201709/162090-20170912153732344-1095971206.png)

**Contains** 查询示例：

![EF Contains](https://images2017.cnblogs.com/blog/162090/201709/162090-20170912153746266-1373484800.png)

上面运行的结果，*Like* 查询的结果返回三条记录，而 *Contains* 查询的结果无任何数据返回。

我们借助 SQL Server Profiler 分别捕获这两个示例实际生成的SQL查询。

**EF.Functions.Like** 查询生成的SQL语句：

```SQL
    SELECT [item].[CategoryID], [item].[CategoryName]
    FROM [Category] AS [item]
    WHERE [item].[CategoryName] LIKE N'%[a-c]%'
```

**Contains** 查询生成的SQL语句：

```SQL
    SELECT [item].[CategoryID], [item].[CategoryName]
    FROM [Category] AS [item]
    WHERE CHARINDEX(N'[a-c]', [item].[CategoryName]) > 0
```

通过上面示例以及捕获的SQL，我们可以得知，`EF.Functions.Like()` 查询会被解释成为 `Like`，实际上是查询字符串中包括 *“a”、“b”、“c”* 这三个字符中任何一个字符的数据，而使用 `Contains` 查询会被解析成为 `CharIndex` 函数，实际是指查询字符串中包括 *“[a-c]”* 的字符串。

> **提示：** `StartsWith`和`EndsWith`分别会被解析成为`Left`和`Right`函数，测试结果在这里不再做重复演示。

> **结论：** 在EF Core中提供`EF.Functions.Like()`方法的根本原因是在 TSQL 语句中 `Like` 关键字支持通配符，而在.Net中`StartsWith`、`Contains`和`EndsWith`方法是不支持通配符的；
> 在EF Core中`StartsWith`、`Contains`和`EndsWith`模糊查询实际分别被解析成为`Left`、`CharIndex`和`Right`，而不是`Like`。

## 其它要点

通过上面的示例我们已经说清楚了`EF.Functions.Like()`方法和`StartsWith`、`Contains`和`EndsWith`方法之间的区别，但是还有以下两点需要说明。

### EF Core StartsWith 优化

如果使用`StartWith`方法来实现模糊查询，解析后的SQL语句会包括一个`Like`查询，您可能要说，刚才不是已经讲过吗，`StartsWith`、`Contains`和`EndsWith`方法解析后的SQL不是通过 `Like` 来查询！先不要着急，我下面来说清楚这个问题。

**StartsWith** 查询示例：

```csharp
        [Fact]
        public void StartsWith()
        {
            using (var dataContext = new SampleDbContext())
            {
                var result = dataContext.Categories.Where(item => item.CategoryName.StartsWith("Clo")).ToList();

                foreach (var item in result)
                {
                    _testOutputHelper.WriteLine(item.CategoryName);
                }
            }
        }
```

借助 SQL Server Profiler 捕获实际生成的SQL查询：

```SQL
    SELECT [item].[CategoryID], [item].[CategoryName]
    FROM [Category] AS [item]
    WHERE [item].[CategoryName] LIKE N'Clo' + N'%' AND (LEFT([item].[CategoryName], LEN(N'Clo')) = N'Clo')
```

在SQL语句中，即用到了`Like`，也用到`Left`函数，这是为什么呢？

您可能知道在数据库查询时，如果在某一个字段上使用函数是无法利用到索引的；在使用`Left`，`CharIndex`和`Right`时是无法利用到索引的；而`Like`查询在百分号后置的情况下会利用到索引。关于数据库的这些知识，在博客园上有很多文章，我就不重复说明了。

> **结论：** `StartsWith`模糊查询解析后的SQL用到`Like`，这是因为`Like`在百分号后置的是情况下会利用到索引，这样查询速度会更快。`Contains`和`EndsWith`模糊查询解析后的SQL不包括`Like`查询，因为在分百号前置的情况无法引用到索引。

关于`Contains`和`EndsWith`模糊查询的测试，在这里不再重复，您可以自己测试。

### EF 6

在EF 6中，模糊查询解析后的SQL语句与EF Core中略有不同，但是执行的结果没有区别。

我们在EF 6中分别捕获`StartsWith`、`Contains`和`EndsWith`解析后的SQL语句，不过我们搜索的关键字是：**“[a-c]”**，包含通配符。

**StartsWith** 查询生成的SQL语句：

```SQL
SELECT 
    [Extent1].[CategoryID] AS [CategoryID], 
    [Extent1].[CategoryName] AS [CategoryName]
    FROM [dbo].[Category] AS [Extent1]
    WHERE [Extent1].[CategoryName] LIKE N'~[a-c]%' ESCAPE N'~'
```

**Contains** 查询生成的SQL语句：

```SQL
SELECT 
    [Extent1].[CategoryID] AS [CategoryID], 
    [Extent1].[CategoryName] AS [CategoryName]
    FROM [dbo].[Category] AS [Extent1]
    WHERE [Extent1].[CategoryName] LIKE N'%~[a-c]%' ESCAPE N'~'
```

**EndsWith** 查询生成的SQL语句：

```SQL
SELECT 
    [Extent1].[CategoryID] AS [CategoryID], 
    [Extent1].[CategoryName] AS [CategoryName]
    FROM [dbo].[Category] AS [Extent1]
    WHERE [Extent1].[CategoryName] LIKE N'%~[a-c]' ESCAPE N'~'
```

`StartsWith`、`Contains`和`EndsWith`方法均会被解析为`Like`查询，但是是传递的参数由：**“[a-c]”**变为了**“[a-b]”\**，前面多了一个特殊符号\**“”**，并且查询子句的后面还多了一部分 **ESCAPE N'~'**。

在MSDN上面有关`ESCAPE`关键字的解释，我们摘取其中一部分来说明：

> **使用 ESCAPE 子句的模式匹配**
> 搜索包含一个或多个特殊通配符的字符串。 例如，customers 数据库中的 discounts 表可能存储含百分号 (%) 的折扣值。 若要搜索作为字符而不是通配符的百分号，必须提供 ESCAPE 关键字和转义符。 例如，一个样本数据库包含名为 comment 的列，该列含文本 30%。 若要搜索在 comment 列中的任何位置包含字符串 30% 的任何行，请指定 WHERE comment LIKE '%30!%%' ESCAPE '!' 之类的 WHERE 子句。 如果未指定 ESCAPE 和转义符，则数据库引擎将返回包含字符串 30 的所有行。

如果您想了解EF 6是如果过滤这些通配符的，可以在Github上面了解，链接地址：https://github.com/aspnet/EntityFramework6/blob/6.1.3/src/EntityFramework.SqlServer/SqlProviderManifest.cs#L164-L189。

> **结论：**在EF 6中`StartsWith`、`Contains`和`EndsWith`方法均会被解析为`Like`查询，但是如果出现了通配符，框架会结合`ESCAPE`以及自身过滤功能将参数进行转义。

## 总结





- 在EF Core中提供`EF.Functions.Like()`方法的根本原因是在 TSQL 语句中 `Like` 关键字支持通配符，而在.Net中`StartsWith`、`Contains`和`EndsWith`方法是不支持通配符的；

- 在EF Core中`StartsWith`、`Contains`和`EndsWith`模糊查询分别被解析成为`Left`、`CharIndex`和`Right`，而不是`Like`。

- 在EF Core中`StartsWith`模糊查询解析后的SQL用到`Like`，这是因为`Like`在百分号后置的是情况下会利用到索引，这样查询速度会更快；

- 在EF 6中，`StartsWith`、`Contains`和`EndsWith`方法均会被解析为`Like`查询，但是如果出现了通配符，框架会结合`ESCAPE`以及自身过滤功能将参数进行转义；

- 在EF 6中，模糊查询不支持通配符，这一点是因为我没有找到对应的解决方案

  例子：

  ~~~ c#
  using Microsoft.EntityFrameworkCore;
         public void GetUserinfo()
          {
              _dbContext.UserInfos.Where(c => EF.Functions.Like(c.UserName, "%风%")).ToList();
          }
  ~~~

  

博客园链接：https://www.cnblogs.com/tdfblog/p/entity-framework-core-like-query.html



