using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace AppPublisherProcess.Process.Entities.Request {
    /// <summary>
    /// Envio de dados dos sensores IoT
    /// </summary>
public class SensorSetStatusRequest {

        /// <summary>
        /// Dados de temperatura
        /// </summary>
        [JsonProperty(PropertyName = "temperature")]
        public SensorSetStatus.Temperature Temperature { get; set; }

        /// <summary>
        /// Intensidade do sensor de luminosidade
        /// </summary>
        [JsonProperty(PropertyName = "ldr")]
        public SensorSetStatus.LDR LDR { get; set; }
    }
}

