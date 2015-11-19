using SensorMonitor.Domain.Entities.Request;
using SensorMonitor.Domain.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorMonitor.Core.Manager.Interface {
    public interface IManagerMsg {
        SensorSetStatusResponse Execute(SensorSetStatusRequest sensorSetStatusRequest);
    }
}
