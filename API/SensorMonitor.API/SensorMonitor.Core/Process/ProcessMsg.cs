using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensorMonitor.Domain.Entities.Request;
using SensorMonitor.Domain.Entities.Response;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace SensorMonitor.Core.Process {
    public class ProcessMsg : Interface.IProcessMsg {

        private string _hostName = null;
        private string _queueName = null;

        public ProcessMsg() {
            this._hostName = "127.0.0.1";
            this._queueName = "SensorMonitorQ1";
        }
       
        public SensorSetStatusResponse SendToBus(SensorSetStatusRequest sensorSetStatusRequest) {

            var factory = new ConnectionFactory() {
                HostName = this._hostName          
            };

            using (var connection = factory.CreateConnection()) {
                using (var channel = connection.CreateModel()) {

                    channel.QueueDeclare(this._queueName, true, false, false, null);

                    string message = Newtonsoft.Json.JsonConvert.SerializeObject(sensorSetStatusRequest);

                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                         routingKey: this._queueName,
                                         basicProperties: null,
                                         body: body);
                }
            }
        
            return new SensorSetStatusResponse() {
                success = true
            };
        }
    }
}
