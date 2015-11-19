using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPublisherProcess.Process.Entities.Request.SensorSetStatus {

    /// <summary>
    /// Dados de temperatura
    /// </summary>
public class Temperature {

        /// <summary>
        /// Temperatura em Celsius
        /// </summary>
        [JsonProperty(PropertyName = "celsius")]
        public string Celsius { get; set; }

        /// <summary>
        /// Temperatura em Fahrenheit
        /// </summary>
        [JsonProperty(PropertyName = "fahrenheit")]
        public string Fahrenheit { get; set; }

        /// <summary>
        /// Valor de resistência
        /// </summary>
        [JsonProperty(PropertyName = "resistence")]
        public string Resistence { get; set; }
    }
}
