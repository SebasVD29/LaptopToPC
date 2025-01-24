using APICentral.IBLL;
using APICentral.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace APICentral.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class ApisController : ControllerBase
    {
        private readonly IApisBLL _apisBILL;
        public ApisController(IApisBLL apisBILL)
        {
            _apisBILL = apisBILL;
        }

        [HttpGet]
        [Route("ListarAPIs")]
        public async Task<ActionResult<ResponseListaApis>> ListaApis()
        {
            try
            {
                return await _apisBILL.ListaAPIS();
            }
            catch (Exception)
            {

                ResponseListaApis responseApis = new ResponseListaApis();

                ResponseModel responseModel = new ResponseModel();
                responseModel.errorcode = -1;
                responseModel.errormsg = "Error al obtener la lista de Apis";
                responseApis.errores = responseModel;
                return responseApis;



            }
        }
    }
}
