using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorMonitor.Domain.Entities.Response {

    /// <summary>
    /// Resposta da gravação do status
    /// </summary>
    public class SensorSetStatusResponse {

        /// <summary>
        /// Indica se houve sucesso
        /// </summary>
        public bool success { get; set; }
    }
}
