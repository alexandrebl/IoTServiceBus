using AppPublisherProcess.Utility.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPublisherProcess.Utility {
    public class ConfigurationUtility : IConfigurationUtility {

        public ConfigurationUtility() {
            this.ProcessIntervalMiliSeconds = 100;
        }
        public int ProcessIntervalMiliSeconds { get; set; }
        public string QueueHost { get; set; }
        public string QueueName { get; set; }
        public string NoSQLDataBase { get; set; }
        public string NoSQLConnection { get; set; }
        public string NoSQLCollection { get; set; }
        public bool TwitterIntegrationEnabled { get; set; }
        public string TwitterConsumerAPIKey { get; set; }
        public string TwitterConsumerSecretAPIKey { get; set; }
        public string TwitterAccessToken { get; set; }
        public string TwitterAccessTokenSecret { get; set; }
        public string TwitterOwner { get; set; }
        public string TwitterOwnerID { get; set; }
        public string TwitterFormatMsg { get; set; }
    }
}
