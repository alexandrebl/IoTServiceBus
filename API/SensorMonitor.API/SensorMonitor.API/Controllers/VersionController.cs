using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SensorMonitor.API.Controllers {

    /// <summary>
    /// Controle de versão da API
    /// </summary>
    public class VersionController : ApiController {

        /// <summary>
        /// Versão Atual da API
        /// </summary>
        private string _version = "v1.0r01";

        /// <summary>
        /// Obtem a versão atual da API
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Task<HttpResponseMessage> GetVersionAsync() {
            //Resposta
            var response = new HttpResponseMessage() {
                //Conteúdo
                Content = new StringContent(this._version),
                //Código de retorno
                StatusCode = HttpStatusCode.OK
            };

            //Retorno
            return Task.FromResult(response);
        }

    }
}
