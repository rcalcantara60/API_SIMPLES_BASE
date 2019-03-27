using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.IO;
using TCLegis.Bll;
using TCLegis.DAL;
using TCLegis.DAL.DataTransferObject;
using TCLegisAPI.Controllers.Base;

namespace TCLegisAPI.Controllers
{
    [Route("api/[controller]")]
    public class NormasController : BaseController
    {        
        private ServiceBLL _serviceBLL;
        public NormasController(ILogger<NormasController> logger, IConfiguration configuration) : base(logger)
        {

            string conString = ConfigurationExtensions
               .GetConnectionString(configuration, "TCLEGISConnectionString");

            _serviceBLL = new ServiceBLL(conString);
        }

        // GET api/Normas
        /// <summary>
        /// Faz a busca do arquivo de uma norma de acordo com o código do documento.
        /// </summary>
        /// <param name="codigoDocumento">Código do documento.</param>
        /// <returns>Objeto retornado</returns>
        [HttpGet("ObterArquivoNorma")]
        public byte[] ObterArquivoNorma([FromQuery] decimal codigoDocumento)
        {            
            return _serviceBLL.ObterArquivoNorma(codigoDocumento);
        }

        // GET api/Normas
        /// <summary>
        /// Faz a busca de todos os tipos de normas mostrando seu código e descrição.
        /// </summary>
        /// <returns>Objeto retornado</returns>
        [HttpGet("ObterTiposNormas")]
        public IEnumerable<TipoNormaDTO> ObterTiposNormas()
        {
            return _serviceBLL.ObterTiposNormas();
        }

        // GET api/Normas
        /// <summary>
        /// Faz a busca dos documentos.
        /// </summary>
        /// <param name="numero">Número do documento.</param>
        /// <param name="anoCadastro">Ano de cadastro.</param>
        /// <param name="tiposNormas">Tipos das normas que os documentos retornados irão conter.</param>
        /// <returns>Objeto retornado</returns>
        [HttpGet("PesquisarNormas")]
        public IEnumerable<NormaDTO> PesquisarNormas([FromQuery] string numero, [FromQuery] int? anoCadastro, [FromQuery] List<int> tiposNormas)
        {
            return _serviceBLL.PesquisarNormas(numero, anoCadastro, tiposNormas);
        }

    }
}
