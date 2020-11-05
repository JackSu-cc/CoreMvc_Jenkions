### C#基础

1. Object 

   object 是引用类型，但是值类型可以转换为object 类型，object类型也可以转换为值类型，但是转换的过程就产生了装箱或拆箱的操作。

   装箱：值类型转换为引用类型

   拆箱：引用类型转换为值类型

   在Object的扩展方法中包含Equal 方法和常用的“==”还有有区别的，

   假如对比的是**值类型** 则对比的是两个参数的值是否相等，Equal和==是没有区别的，因为值类型存储在栈中，所以对比是相等的。

   假如对比的是**引用类型** 则存在区别，== 对比的是两个值得地址，Equal则对比的是存的值是否相等，因为引用类型是存储在 堆中的，两个对比的参数，值相等，但是分配完成第一个参数后，第二个参数会直接分配内存中的地址指向已存在的值，不会再重新开辟空间。

   **ReferenceEquals** 是object的静态方法，对比的是两个值的引用是否相等。

   

   例子：

   ~~~ c#
   例子1：
   string aa=new string("12");
   string bb=new string("12");
   aa==bb //false
   aa.Equal(bb);//True 
   例子2：
     string a1="11";
     string a2="11";
     a1=a2//true
     a1.Equal(a2);//true
   ~~~

2. GetType和Typeof的区别：

   GetType和Typeof 作用是相同的都是返回使用类型的Type类型。

   Typeof是运算方法，平时使用中会得到一个Class的Type

   GetType是来源于System.Object 类型，所以需要初始化之后才能使用，会得到一个 **实例** 后的Type

3. 值类型和引用类型

   值类型：分配在栈上，保存的是值，每次都会创建一个

   引用类型：分配在堆上，创建两个相同的值，其实际只有一个值，两个内存地址，指向同一个值。

   两个类型的互相转换即为：装箱/拆箱，同类型的转换不算装箱/拆箱

4. 面向对象：封装（内部实现细节与外部展示分开） 继承 多态

   C#共同基类 Object

   类与接口   class和Interface 

   类型安全：

    静态类型：Static Typing

    动态类型：dynamic

    强类型： Strongly Typed language

   内存管理：CLR 公共语言运行时   GC 自动垃圾回收

   隐式转换：编译器保证信息不回丢失 .。比如：int转换为long类型，

   显示转换：编译器不能保证信息会丢失。比如：long转换为int类型，（因为long比int长）

   Using static system  这样的引用方式 表明 system下所有的静态成员不需要 写前面部分直接使用

   方法签名：就是指方法的名字，或者方法参数的名字

   泛型：

   where T ：base-class 某个父类的子类

   where T ：interface    实现了接口

   where T ：Class          必须是class类型

   where T ：Struct         值类型

   where T ：new()         必须有一个无参构造函数

   where u ：T                U继承T函数

   协变 ：当一个值作为返回值out   public Interface IEnumerable<out T>

   逆变 ：当值作为输入                    public delegate void Action<in T>

   不变 ：当值作为输入又作为输出   public Interface  IList<T>

   Task 使用的线程池，主线程结束后，子线程就已经结束了。
   







C#中的异步可以简单的用async 和 await 配合来实现，使用异步的函数，在没有调用await前，还是按顺序单线程执行的，当运行到await的时候，系统才会异步调用其他的方法来运行，如果没有await, 函数就是同步按顺序的运行。所以，await才是异步中的关键部分，在await 范围内的代码，是多线程方式运行的，可以将需要异步处理的代码放在await中运行，或者简单的用一个Task.Delay来延时，以达到异步切换代码运行的效果。await 后面接的是一个Task, 每一个Task在运行时，由系统的Task池来分配，以实现异步的功能。
这里再来说说用aysnc和直接用thread的区别，其实简单来讲，就是效率的问题，async用的线程池，在await中运行的代码是由线程池分配的线程，根据系统的任务，自动分配和释放，而用 new thread的方法，通常是需要手动控制的。很显然，在处理一些短时间，且对运行的时间性和稳定性不是特别严格的问题时，用async会很有优势，但是对于一些在后台需要长时间稳定运行的程序，用thread会更好

