using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Stuant
    {
        public static int Pss(this object s)
        {
            return 1;
        }

    }
    class Program
    {

        static void Main(string[] args)
        {
            var len = 9;
            string st;
            for (var i = 1; i <= len; i++)
            {
                st = "";
                for (var j = 1; j <= i; j++)
                {
                    if (j == i)
                    {
                        st += $"{j}*{i}={i * j}";
                        
                        break;
                    } 
                    else
                    {
                        st += $"{j}*{i}={i * j}\t";
                    }
                }
                Console.WriteLine(st);
            }


            List<string> listA = new List<string> { "a", "b", "c", "d", "e" };

            List<string> listB = new List<string> { "a", "b", "f" };

            var str3 = listB.ToArray().Except(listA.ToArray()).Any();

            Console.WriteLine(str3);
            string expression = "@IsHighRisk=0&&@YearCost<1000000&&((@IsBack=1&&@TCV<50000)||@IsBack=0)";

            expression = expression
                .Replace("@IsHighRisk", "0")
                .Replace("@YearCost", "100")
                .Replace("@IsBack", "1")
                 .Replace("@TCV", "10");



            object result = new DataTable().Compute(expression, "");
            Console.WriteLine(float.Parse(result + ""));

            //  string dd = "abcadddd";

            //  List<char> li = new List<char>();
            //  int n = dd.Length;
            //  int max = 0;
            //  for (int i = 0; i < n; i++)
            //  {
            //      if (li.Contains(dd[i]))
            //      {
            //          li.RemoveRange(0,li.IndexOf(dd[i])+1);
            //      }
            //      li.Add(dd[i]);
            //      max = li.Count > max ? li.Count : max;
            //  }
            //var ss=  max;

            #region 深复制，浅复制
            string aa = "sdf";
            string dd12 = null;
            Console.WriteLine(aa);
            Console.WriteLine(dd12);
            dd12 = aa;
            Console.WriteLine(dd12);
            dd12 = "aaa";
            Console.WriteLine(aa);
            Console.WriteLine(dd12);

            user u1 = new user()
            {
                name = "原始的"
            };
            Console.WriteLine(u1.name);
            user u2 = u1;
            Console.WriteLine(u2.name);
            u2.name = "第一次浅复制";
            Console.WriteLine(u1.name);
            Console.WriteLine(u2.name);

            #endregion



            Audi audi = new Audi();
            audi[1] = "A6";
            audi[2] = "A8";
            Console.WriteLine(audi[1]);
            audi.Run();
            audi.ShowResult();

            string dd = "";
            int dds = dd.Pss();



            List<AAA> list = new List<AAA>();
            list.Add(new AAA { Name = "" });
            list.Where(c => c.Name.Contains("ss"));


            Console.WriteLine("Hello World!");

            //数据类型 float参数后面必须是加 f  不然编译不过去，会被编译器认为是 double
            // decimal 类型如果直接赋值必须加 m  不然编译不过去，会被编译器认为是 double
            float a = 3.2f;
            decimal b = 3.2m;

            //float 精度不足，会丢失位数
            int a1 = 10000001;
            float a2 = a1; //变成 1E+80 //丢失 1
            int a3 = (int)a2;// 变成1000000

            //整数类型没有自己的操作符   byte sbyte ushort short
            short s1 = 1;
            short s2 = 2;
            short s3 = (short)(s1 + s2);

            int i1 = 0;
            Console.WriteLine(i1++);
            Console.WriteLine(++i1);

            Console.WriteLine("await外面的前面");

            Getasync();

            Console.WriteLine("await外面的后面");
            Console.ReadKey();
        }
        public static async void Getasync()
        {
            int tt = 0;
            Console.WriteLine("await后面{0}", tt);
            tt = await Task.Run(() =>
               {

                   for (int i = 0; i < 5; i++)
                   {
                       Thread.Sleep(1000);
                       tt = tt + i;
                   }
                   return tt;
               });
            Console.WriteLine("await后面");
            Console.WriteLine("await后面{0}", tt);


        }

        public class user
        {
            public string name { get; set; }
        }


        public class Action
        {
            public static void ToRun(Vehicle vehicle)
            {
                Console.WriteLine("{0} is running.", vehicle.ToString());
            }
        }
        public class Vehicle
        {
            private string name;
            private int speed;
            private string[] array = new string[10];

            public Vehicle()
            {
            }

            //限定被相似的名称隐藏的成员
            public Vehicle(string name, int speed)
            {
                this.name = name;
                this.speed = speed;
            }

            public virtual void ShowResult()
            {
                Console.WriteLine("The top speed of {0} is {1}.", name, speed);
            }

            public void Run()
            {
                //传递当前实例参数
                Action.ToRun(this);
            }
            //声明索引器，必须为this，这样就可以像数组一样来索引对象
            public string this[int param]
            {
                get { return array[param]; }
                set { array[param] = value; }
            }
        }



        public class Car : Vehicle
        {
            //派生类和基类通信，以base实现，基类首先被调用
            //指定创建派生类实例时应调用的基类构造函数
            public Car()
                : base("Car", 200)
            { }

            public Car(string name, int speed)
                : this()
            { }

            public override void ShowResult()
            {
                //调用基类上已被其他方法重写的方法
                base.ShowResult();
                Console.WriteLine("It's a car's result.");
            }

        }

        public class Audi : Car
        {
            public Audi()
                : base("Audi", 300)
            { }

            public Audi(string name, int speed)
                : this()
            {
            }

            public override void ShowResult()
            {
                //由三层继承可以看出，base只能继承其直接基类成员
                base.ShowResult();
                base.Run();
                Console.WriteLine("It's audi's result.");
            }
        }


    }

    public class AAA
    {
        public string Name { get; set; }
    }




}
