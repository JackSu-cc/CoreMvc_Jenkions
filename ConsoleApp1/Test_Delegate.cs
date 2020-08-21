
//******************************************************************/
// Copyright (C) 2020 All Rights Reserved.
// CLR版本：4.0.30319.42000
// 版本号：V1.0.0
// 文件名：Test_Delegate
// 创建者：名字 (cc)
// 创建时间：2020/8/17 21:19:50
//
// 描述：
//
// 
//=================================================================
// 修改人：
// 时间：
// 修改说明：
// 
//******************************************************************/


using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{

    public delegate void ReceiveEmail();
    public class Test_Delegate
    {
        //正常声明委托
        public delegate void testDelegate();
         

        public Test_Delegate()
        {
            testDelegate @delegate = new testDelegate(GetInfo);
            @delegate += new testDelegate(GetInfoNew);
            @delegate.Invoke();

            Action action = new Action(GetInfo);
            action += new Action(GetInfoNew);
            action.Invoke();


            ReceiveEmailEvent emailEvent = new ReceiveEmailEvent();
            ReceiveEmail receive= new ReceiveEmail(emailEvent.Receive);
            receive.Invoke();
           
        }

     

        public static void GetInfo()
        {
            Console.WriteLine("静态委托方法");
        }

        public void GetInfoNew()
        {
            Console.WriteLine("非静态委托方法");
        }

        public void AEventArgs(object sender, System.EventArgs e)
        {
            Console.WriteLine("My event is ok!");
        }
        

    }

    public class ReceiveEmailEvent //发布者
    {
        public event ReceiveEmail ForwardEvent;

        public void Forward()
        {
            Console.WriteLine("事件方法，转发邮件！");
        }

        
        public void Receive()   //触发事件的方法
        {
            Console.WriteLine("委托方法，接收邮件！");
           // ForwardEvent();
        }

    }
}
