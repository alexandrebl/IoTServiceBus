using AppPublisherProcess.Process.Interface;
using AppPublisherProcess.Utility.Interface;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPublisherProcess.Process {
    public class ProcessMQ : IProcessMQ {

        private IConfigurationUtility ConfigurationUtility { get; set; }

        public ProcessMQ(IConfigurationUtility configurationUtility) {
            this.ConfigurationUtility = configurationUtility;
        }
        public string GetLastMsg() {

            var msg = String.Empty;

            var factory = new ConnectionFactory() {
                HostName = this.ConfigurationUtility.QueueHost
            };

            using (var connection = factory.CreateConnection()) {
                using (var channel = connection.CreateModel()) {
                    channel.QueueDeclare(this.ConfigurationUtility.QueueName, true, false, false, null);

                    var consumer = new QueueingBasicConsumer(channel);

                    channel.BasicConsume(this.ConfigurationUtility.QueueName, false, consumer);

                    channel.BasicAck(1, false);

                    if (consumer.Queue.Any()) {

                        var data = consumer.Queue.Dequeue();                        

                        msg = Encoding.UTF8.GetString(data.Body);

                        Console.WriteLine(msg);
                    } else {
                        Console.WriteLine("Service bus is empty");
                    }
                }
            }

            return msg;
        }
    }
}
