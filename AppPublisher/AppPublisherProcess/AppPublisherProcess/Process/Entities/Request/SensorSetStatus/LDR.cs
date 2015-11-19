using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPublisherProcess.Process.Entities.Request.SensorSetStatus {


    /// <summary>
    /// Intensidade do sensor de luminosidade
    /// </summary>
public class LDR {

        /// <summary>
        /// Valor atual
        /// </summary>
        [JsonProperty(PropertyName = "intensity")]
        public string Intensity { get; set; }
    }
}
