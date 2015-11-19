using AppPublisherProcess.Manager;
using AppPublisherProcess.Manager.Interface;
using AppPublisherProcess.Process;
using AppPublisherProcess.Process.Interface;
using AppPublisherProcess.Utility;
using AppPublisherProcess.Utility.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppPublisherProcess {
    public class Program {
        static void Main(string[] args) {
            Console.WriteLine("Process initialized");

            IConfigurationUtility configurationUtility = new ConfigurationUtility() {
                ProcessIntervalMiliSeconds = 100,
                NoSQLConnection = "mongodb://localhost",
                NoSQLDataBase = "IoT",
                QueueHost = "127.0.0.1",
                QueueName = "SensorMonitorQ1",
                NoSQLCollection = "SensorMonitor",
                TwitterIntegrationEnabled = false,
                TwitterConsumerAPIKey = "JMxmntUIgiZ4RWR83ZWutEzJ3",
                TwitterConsumerSecretAPIKey = "608iDXSQZqs6s7HazPhx7ahdhq7EXsPuneBPQYhHz0PWliLgKn",
                TwitterAccessToken = "4219798612-4JrAYiJ0uNI1dwvZzsjQV97DLL6DOPD1QWTwDVE",
                TwitterAccessTokenSecret = "CLAFuiyO500udbY3Xd2IpMeoPRHW1R0Fn7Svrco3AozP9",
                TwitterOwner = "iotdevweek",
                TwitterOwnerID = "4219798612",
                TwitterFormatMsg = "IoT Information / SENAC POA - Teperatura: {0}ºC / LDR: {1}",
            };

            IProcessMQ processMQ = new ProcessMQ(configurationUtility);

            IProcessNoSQL processNoSQL = new ProcessNoSQL(configurationUtility);

            IProcessTwitter processTwitter = new ProcessTwitter(configurationUtility);

            IManagerMsg managerMsg = new ManagerMsg(configurationUtility, processMQ, processNoSQL, processTwitter);

            int counter = 0;

            while (true) {
                Console.WriteLine(String.Format("{0} - Execute manager - Waiting for message on bus", ++counter));

                try {
                    managerMsg.Execute();
                } catch (Exception ex) {
                    Console.WriteLine(ex.ToString() + "\n\n\n");
                    Thread.Sleep(5000);
                } finally {
                    Thread.Sleep(configurationUtility.ProcessIntervalMiliSeconds);
                }
            }            
        }
    }
}
