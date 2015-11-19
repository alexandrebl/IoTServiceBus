using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPublisherProcess.Utility.Interface {
    public interface IConfigurationUtility {
        int ProcessIntervalMiliSeconds { get; set; }
        string QueueHost { get; set; }
        string QueueName{ get; set; }
        string NoSQLConnection { get; set; }
        string NoSQLDataBase { get; set; }
        string NoSQLCollection { get; set; }
        bool TwitterIntegrationEnabled { get; set; }
        string TwitterConsumerAPIKey { get; set; }
        string TwitterConsumerSecretAPIKey { get; set; }
        string TwitterAccessToken { get; set; }
        string TwitterAccessTokenSecret { get; set; }
        string TwitterOwner { get; set; }
        string TwitterOwnerID { get; set; }

        string TwitterFormatMsg { get; set; }
    }
}
