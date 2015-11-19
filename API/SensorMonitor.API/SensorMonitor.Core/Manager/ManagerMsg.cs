using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensorMonitor.Domain.Entities.Request;
using SensorMonitor.Domain.Entities.Response;

namespace SensorMonitor.Core.Manager {
    public class ManagerMsg : Interface.IManagerMsg {

        private Process.Interface.IProcessMsg ProcessMsg { get; set; }
        public ManagerMsg(Process.Interface.IProcessMsg processMsg) {
            this.ProcessMsg = processMsg;
        }
        public SensorSetStatusResponse Execute(SensorSetStatusRequest sensorSetStatusRequest) {
            return this.ProcessMsg.SendToBus(sensorSetStatusRequest);
        }
    }
}
