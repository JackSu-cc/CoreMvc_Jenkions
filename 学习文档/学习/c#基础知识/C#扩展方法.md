### C#扩展方法

> 扩展方法是指对代码现有类型的添加，不需要创建新的派生类型。在.net4版本中提出的，
>
> 扩展方法是对现有类型的添加，所以必须要有一个类型，比如需要添加一个string类型的方法，那么扩展方法的参数就是string类型。
>
> 扩展方法也是方法，则需要一个类单独去写扩展方法，这样的类有两点注意：
>
> ​                   1.需要顶级是静态方法。
>
> ​                   2.对客户代码有足够的权限。
>
> ​                   3.扩展方法的参数必须要以 this 头
>
> ~~~c#
> public static class StringExtentsion
>  {
>         public static bool IsEmpty(this string str)
>         {
>             return string.IsNullOrWhiteSpace(str);
>         }
>  }
> 
>  class Program
>     {
>         static void Main(string[] args)
>         {
>             string[] arr = new string[] { null, string.Empty, " ", "  \t  ", "   \r\n   " };
>  
>             foreach (string str in arr)
>             {
>                 bool result = str.IsEmpty();
>  
>                 Console.WriteLine(result); // 编译通过，运行无异常，并且全部输出True
>             }
>              
>             Console.Read();
>         }
>     }
> ~~~
>
> 
>
> 