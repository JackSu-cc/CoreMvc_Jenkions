## Entity Framework 特性:

- **跨平台：** EF Core 是一个跨平台的框架，它可以运行在 Windows，Linux和 Mac上。
- **建模：** EF (Entity Framework) 创建一个基于 POCO (Plain Old CLR Object) 实体的 EDM (Entity Data Model)，POCO实体含有不同数据类型的get/set 属性 （properties）。EF 在查询和保存实体数据到底层数据库的时候会使用 EDM 模型。
- **查询：** EF 允许我们使用 LINQ 查询（C#/VB.NET）从底层数据库检索数据。数据库提供器将 LINQ 查询转换成特定数据库的查询语言（例如：关系型数据库的SQL）.EF也允许我们执行原生的SQL查询来查询数据库。
- **改变跟踪：** 实体实例中 (Property values) 中发生的需要被提交到数据库的任意改变将被 EF 持续跟踪。
- **保存：** 当你调用`SaveChanges()`方法时，EF会根据你的实体的改变执行INSERT, UPDATE, 和DELETE命令。EF也提供异步方法`SaveChangesAsync()`。
- **并发：** 当其他用户从数据库获取数据后要重写数据时，EF默认采用乐观并发（Optimistic Concurrency）。
- **事务：** 当查询和保存数据时，EF执行自动事物管理。EF也提供了定制事务管理的选项。
- **缓存：** EF包含开箱即用的第一级缓存。所以，重复查询将会返回缓存中的数据，而不是再次访问数据库。
- **内置约定：** EF遵循约定高于配置的编程模式，并且包含了一组默认规则用来自动配置EF模型。
- **配置：** EF允许我们使用数据注释特性或者 Fluent API 来重写默认的约定。
- **迁移：** EF提供了一组迁移命令，可以在 NuGet Package Manager Console 或者 Command Line Interface 中创建和管理底层数据库架构。
- 