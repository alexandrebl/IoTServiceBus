using AppPublisherProcess.Manager.Interface;
using AppPublisherProcess.Process.Interface;
using AppPublisherProcess.Utility.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPublisherProcess.Manager {
    public class ManagerMsg : IManagerMsg {

        private IConfigurationUtility ConfigurationUtility { get; set; }
        private IProcessMQ ProcessMQ { get; set; }
        private IProcessNoSQL ProcessNoSQL { get; set; }
        private IProcessTwitter ProcessTwitter { get; set; }
        public ManagerMsg(IConfigurationUtility configurationUtility, 
            IProcessMQ processMQ, IProcessNoSQL processNoSQL, IProcessTwitter processTwitter) {
            this.ConfigurationUtility = configurationUtility;
            this.ProcessMQ = processMQ;
            this.ProcessNoSQL = processNoSQL;
            this.ProcessTwitter = processTwitter;
        }
        public bool Execute() {
            string lastMsg = this.ProcessMQ.GetLastMsg();

            if (!String.IsNullOrEmpty(lastMsg)) {
                this.ProcessNoSQL.SendDocument(lastMsg);

                this.ProcessTwitter.SendToCloud(lastMsg);
            }

            return true;
        }
    }
}
