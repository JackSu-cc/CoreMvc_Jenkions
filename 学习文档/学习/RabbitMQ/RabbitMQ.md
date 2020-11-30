## RabbitMQ





### 交换机 ExChange

1. Direct ：提前预知性的交换机 交换机与队列直接绑定
2. Fanout：群发性的交换机
3. Topic：
4. Harders：





### Queue特性

1. QueueDeclare 声明队列

   * `durable`： 持久化 ，当服务器重启之后队列依旧存在。

   * `exclusive`： 排外的，当前连接中的队列是被锁定的，其他连接访问是访问不到的，当连接关闭时，对列被删除。

   * `autoDelete`： 自动删除，当前最后一个consumer被订阅时会被删除。

   * `passive`：是不存在此参数，但是与  ’3‘ 中的消极队列是相同的。

   * `arguments`： 给队列设置一些限定，

     ​                               x-message-ttl  1000*8   //队列中的所有消息只存在8秒

     ​                               消息发布时可以设置指定消息自动删除

     ​                               Auto Expire 自动删除：设置队列在指定时间未访问则被删除

     ​                               Max Length：【x-Max-Length  1000】指定队列最大长度，比如1000为最大长度，则是超过1000进不了队列。

     ​                                Max Length Byte  限定消息的大小

     ​                                消息过期，推送到新的队列上进行记入到数据库里。

     ​                                 `队列优先级`  x-Max-priority=10,优先级最高

     ​                                

2. QueueDeclareNoWait  异步申明队列： 底层与QueueDeclare相同

3. QueueDeclarePassive 消极队列 ： **判断队列是否存在，不存在有异常，不做任何操作**

### Basic

 确认方式：

                  *  自动确认：出队列时自动确认
                  *  手动确认：消息出队列时，手动执行确认方法

