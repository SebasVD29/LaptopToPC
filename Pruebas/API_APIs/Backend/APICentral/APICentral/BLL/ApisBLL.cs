using APICentral.IBLL;
using APICentral.IServicios;
using APICentral.Modelo;

namespace APICentral.BLL
{
    public class ApisBLL : IApisBLL
    {
        private readonly IApisServicios _apisServicios;

        public ApisBLL(IApisServicios ApisServicios)
        {
            _apisServicios = ApisServicios;
        }
        public async Task<ResponseListaApis> ListaAPIS()
        {
            try
            {
                var listaApis = await _apisServicios.ListaAPIS();

                ResponseListaApis responseLista = new ResponseListaApis();
                ResponseModel responseModel = new ResponseModel();
                responseLista.apis = listaApis.ToList();
                responseModel.errorcode = 0;
                responseModel.errormsg = "Lista de Apis devuelta con éxito";

                responseLista.errores = responseModel;

                return responseLista;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
