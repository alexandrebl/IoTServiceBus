using AppPublisherProcess.Process.Entities.Request;
using AppPublisherProcess.Process.Interface;
using AppPublisherProcess.Utility.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Core.Credentials;
using Tweetinvi;

namespace AppPublisherProcess.Process {
    public class ProcessTwitter : IProcessTwitter {

        private static DateTime timeSync = DateTime.Now.AddMinutes(-1);
        private IConfigurationUtility ConfigurationUtility { get; set; }

        public ProcessTwitter(IConfigurationUtility configurationUtility) {
            this.ConfigurationUtility = configurationUtility;
        }
        public void SendToCloud(string data) {
            if (timeSync.Minute != DateTime.Now.Minute) {
                timeSync = DateTime.Now;

                var sensorData = JsonConvert.DeserializeObject<SensorSetStatusRequest>(data);

                if (sensorData != null) {

                    if (!String.IsNullOrEmpty(sensorData?.Temperature.Celsius) && (sensorData?.Temperature.Celsius.Length >= 5)) {
                        var credentials = new TwitterCredentials(this.ConfigurationUtility.TwitterConsumerAPIKey,
                                this.ConfigurationUtility.TwitterConsumerSecretAPIKey, this.ConfigurationUtility.TwitterAccessToken,
                            this.ConfigurationUtility.TwitterAccessTokenSecret);

                        var tweet = Auth.ExecuteOperationWithCredentials(credentials, () => {
                            return Tweet.PublishTweet(String.Format(ConfigurationUtility.TwitterFormatMsg, 
                                sensorData?.Temperature.Celsius.Substring(0, 5).Replace(".", ","),
                                    sensorData?.LDR.Intensity));
                        });
                    }
                }
            }
        }
    }
}
