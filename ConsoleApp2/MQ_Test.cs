
//******************************************************************/
// Copyright (C) 2020 All Rights Reserved.
// CLR版本：4.0.30319.42000
// 版本号：V1.0.0
// 文件名：MQ_Test
// 创建者：名字 (cc)
// 创建时间：2020/11/17 23:08:21
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
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ConsoleApp2
{
    public static class MQ_Test
    {

        public static void ReceivedTest()
        {
            IConnectionFactory conFactory = new ConnectionFactory//创建连接工厂对象
            {
                HostName = "192.168.31.58",//IP地址
             
                UserName = "cc",//用户账号
                Password = "123456"//用户密码
            };

            var con = conFactory.CreateConnection();//创建连接

            var chanel = con.CreateModel();//创建通道

           var result= chanel.BasicGet("firstqueue",true);

            var msg = Encoding.UTF8.GetString(result.Body.ToArray());
             
            Console.WriteLine($"收到消息： {msg}");
 
            chanel.Dispose();
            con.Close();

            Console.ReadKey();

        }
    }
}
