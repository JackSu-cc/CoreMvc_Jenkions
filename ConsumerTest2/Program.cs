using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace ConsumerTest2
{
    class Program
    {
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

            //定义交换机
            chanel.ExchangeDeclare("fanoutExchange", ExchangeType.Fanout, true, false, null);
             
            //声明队列2
            chanel.QueueDeclare("fanoutQueue2", true, false, false, null);

            //队列与交换机绑定  routingKey 在fanout模式下不需要
            chanel.QueueBind("fanoutQueue2", "fanoutExchange", "", null);

            var consumer1 = new EventingBasicConsumer(chanel);
            consumer1.Received += (model, er) => {
                var msg = Encoding.UTF8.GetString(er.Body.ToArray());
                Console.WriteLine($"收到消息： {msg}");
            };

            chanel.BasicConsume("fanoutQueue2", true, consumer1);

            #endregion

            Console.ReadKey();
        }
    }
}
