using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsumerTest1
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
            public List<string> RoutingKey { get; set; }
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

            #region 简单模式、工作模式下的消费者

            ////var result = chanel.BasicGet("firstqueue", true);
            //var result = chanel.QueueDeclare("firstqueue", true, false, false, null);

            //var consumer1 = new EventingBasicConsumer(chanel);

            //consumer1.Received += (model, er) => {
            //    var msg = Encoding.UTF8.GetString(er.Body.ToArray());
            //    Console.WriteLine($"收到消息： {msg}");
            //};

            //chanel.BasicConsume("firstqueue", true, consumer1);

            #endregion
            //chanel.Dispose();
            //con.Close();

            #region Fanout模式下的消费者

            ////定义交换机
            //chanel.ExchangeDeclare("fanoutExchange", ExchangeType.Fanout, true, false, null);

            ////声明队列1
            //chanel.QueueDeclare("fanoutQueue1", true, false, false, null);

            ////队列与交换机绑定  routingKey 在fanout模式下不需要
            //chanel.QueueBind("fanoutQueue1", "fanoutExchange", "", null);

            //var consumer1 = new EventingBasicConsumer(chanel);
            //consumer1.Received += (model, er) => {
            //    var msg = Encoding.UTF8.GetString(er.Body.ToArray());
            //    Console.WriteLine($"收到消息： {msg}");
            //};

            //chanel.BasicConsume("fanoutQueue1", true, consumer1);

            #endregion


            #region direct 路由模式

            //par.Exchange = "directExchange";
            //List<string> li = new List<string>
            //{
            //    "directQueueElse"
            //};
            //par.QueueList= li;
            //List<string> li_key = new List<string>
            //{
            //    "routing_info",//输出信息
            //    "routing_debug"//运行状态
            //};
            //par.RoutingKey = li_key;
            ////定义交换机
            //chanel.ExchangeDeclare(par.Exchange, ExchangeType.Direct, true, false, null);

            ////声明队列1
            //chanel.QueueDeclare(par.QueueList[0], true, false, false, null);
            ////交换机与队列绑定
            //foreach (var item in par.RoutingKey)
            //{
            //    chanel.QueueBind(par.QueueList[0], par.Exchange, item, null);
            //}

            //var consumer1 = new EventingBasicConsumer(chanel);
            //consumer1.Received += (model, er) =>
            //{
            //    var msg = Encoding.UTF8.GetString(er.Body.ToArray());
            //    Console.WriteLine($"收到消息： {msg}");
            //};

            //chanel.BasicConsume(par.QueueList[0], true, consumer1);
            #endregion

            #region topic 通配符模式

            par.Exchange = "TopicExchange";
            List<string> li = new List<string>
            {
                "TopicQueue_com"
            };
            par.QueueList = li;
            List<string> li_key = new List<string>
            {
                "*.com",
            };
            par.RoutingKey = li_key;
            //定义交换机
            chanel.ExchangeDeclare(par.Exchange, ExchangeType.Topic, true, false, null);

            //声明队列1
            chanel.QueueDeclare(par.QueueList[0], true, false, false, null);
            //交换机与队列绑定

            chanel.QueueBind(par.QueueList[0], par.Exchange, par.RoutingKey[0], null);


            var consumer1 = new EventingBasicConsumer(chanel);
            consumer1.Received += (model, er) =>
            {
                var msg = Encoding.UTF8.GetString(er.Body.ToArray());
                Console.WriteLine($"收到消息： {msg}");
            };

            chanel.BasicConsume(par.QueueList[0], true, consumer1);
            #endregion


            Console.ReadKey();
        }

    }
}
