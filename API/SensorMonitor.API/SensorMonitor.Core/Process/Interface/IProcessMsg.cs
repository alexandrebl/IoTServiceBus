using SensorMonitor.Domain.Entities.Request;
using SensorMonitor.Domain.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorMonitor.Core.Process.Interface {
    public interface IProcessMsg {

        SensorSetStatusResponse SendToBus(SensorSetStatusRequest sensorSetStatusRequest);
    }
}
