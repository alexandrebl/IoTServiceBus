using SensorMonitor.Core.Manager.Interface;
using SensorMonitor.Core.Manager;
using SensorMonitor.Core.Process.Interface;
using SensorMonitor.Core.Process;
using SensorMonitor.Domain.Entities.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Practices.Unity;
using SensorMonitor.API.Library.Utility;

namespace SensorMonitor.API.Controllers
{
    /// <summary>
    /// Controlador dos sensores
    /// </summary>
    public class SensorController : ApiController {

        private IUnityContainer _unityContainer = null;
        private IProcessMsg ProcessMsg { get; set; }
        private IManagerMsg ManagerMsg { get; set; }

        public SensorController() {
            this._unityContainer = IoCUtility.GetInstance();

            this.ProcessMsg = _unityContainer.Resolve<IProcessMsg>();
            this.ManagerMsg = _unityContainer.Resolve<IManagerMsg>();
        }

        /// <summary>
        /// Grava o status dos sensores
        /// </summary>
        /// <param name="sensorSetStatusRequest">Requisição de gravação de status</param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult SetStatusAsync(SensorSetStatusRequest sensorSetStatusRequest) {
            try {
                //Retorno
                return Ok(this.ManagerMsg.Execute(sensorSetStatusRequest));
            } catch (Exception ex) {
                //Informa o erro interno
                return InternalServerError(ex);
            }
        }
    }
}
