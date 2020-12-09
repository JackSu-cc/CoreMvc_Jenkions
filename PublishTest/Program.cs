﻿using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishTest
{
    class Program
    {
        /// <summary>
        /// 所需参数
        /// </summary>
        public class Parem
        { 
            /// <summary>
            /// 交换机
            /// </summary>
            public string Exchange { get; set; }

            /// <summary>
            /// 队列
            /// </summary>
            public List<string> QueueList { get; set; }

            /// <summary>
            /// routingKey
            /// </summary>
            public string RoutingKey { get; set; }
        }


        static void Main(string[] args)
        {



            IConnectionFactory conFactory = new ConnectionFactory//创建连接工厂对象
            {
                HostName = "192.168.31.58",//IP地址 
                UserName = "cc",//用户账号
                Password = "123456"//用户密码
            };

            var con = conFactory.CreateConnection();//创建连接

            var chanel = con.CreateModel();//创建通道

            var par = new Parem();

            #region 绑定队列，默认的两种模式 简单模式：【发送默认交换机创建队列】、工作模式：【发送默认交换机，两个消费者订阅队列中的消息】；

            //chanel.QueueDeclare("firstqueue", true, false, false, null);//声明队列
            //while (true)
            //{

            //    var publish = Console.ReadLine();

            //    var sendBytes = Encoding.UTF8.GetBytes($"发送端：{publish}");
            //    chanel.BasicPublish("", "firstqueue", null, sendBytes);
            //}
            #endregion

            #region Fanout ：交换机为Fanpout模式，多个队列绑定到此交换机上，发送消息后，订阅的队列都可以收到一份消息

            //par.Exchange = "fanoutExchange";
            //par.QueueList.Add("fanoutQueue1");
            //par.QueueList.Add("fanoutQueue2");
            //par.RoutingKey = "";
            ////定义交换机
            //chanel.ExchangeDeclare(par.Exchange, ExchangeType.Fanout,true, false, null);

            ////声明队列1
            //chanel.QueueDeclare(par.QueueList[0], true, false, false, null);

            ////声明队列2
            //chanel.QueueDeclare(par.QueueList[1], true, false, false, null);

            ////队列与交换机绑定  routingKey 在fanout模式下不需要
            //chanel.QueueBind(par.QueueList[0], par.Exchange, par.RoutingKey, null);
            ////队列与交换机绑定
            //chanel.QueueBind(par.QueueList[1], par.Exchange, par.RoutingKey, null);
            //while (true)
            //{ 
            //    var publish = Console.ReadLine();

            //    var sendBytes = Encoding.UTF8.GetBytes($"发送端：{publish}");
            //    chanel.BasicPublish(par.Exchange, par.RoutingKey, null, sendBytes);
            //}
            #endregion

            #region 路由模式 匹配路由的routingKey  交换机为direct
            par.Exchange = "directExchange";
            par.QueueList.Add("directQueue1");
            par.QueueList.Add("directQueue2");
            par.RoutingKey = "routing";
            //定义交换机
            chanel.ExchangeDeclare(par.Exchange, ExchangeType.Direct, true, false, null);

            //声明队列1
            chanel.QueueDeclare(par.QueueList[0], true, false, false, null);

            //声明队列2
            chanel.QueueDeclare(par.QueueList[1], true, false, false, null);

            //队列与交换机绑定  routingKey  
            chanel.QueueBind(par.QueueList[0], par.Exchange, par.RoutingKey, null);
            //队列与交换机绑定
            chanel.QueueBind(par.QueueList[1], par.Exchange, par.RoutingKey, null);
            while (true)
            {
                var publish = Console.ReadLine();

                var sendBytes = Encoding.UTF8.GetBytes($"发送端：{publish}");
                chanel.BasicPublish(par.Exchange, par.RoutingKey, null, sendBytes);
            }
            #endregion

        }
    }
}
