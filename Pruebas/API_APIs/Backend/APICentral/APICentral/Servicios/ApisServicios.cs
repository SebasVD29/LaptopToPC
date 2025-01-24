using APICentral.IDapper;
using APICentral.IServicios;
using APICentral.Modelo;
using Dapper;
using System.Data;

namespace APICentral.Servicios
{
    public class ApisServicios : IApisServicios
    {
        private readonly IDapperContext _context;
        // inyectamos la interfaz de IDapperContext para poder obtener cadena de conexion en cada método
        public ApisServicios(IDapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<APIs>> ListaAPIS()
        {
            try
            {
                using (var conn = _context.CrearConexion())
                {
                    return await conn.QueryAsync<APIs>("SELECT dbo.API.url, dbo.ControllerAPI.controllerNombre, dbo.EndPoints.endPointNombre, dbo.EndPoints.endPointParametros, dbo.EndPoints.endPointMetodo " +
                                                        "FROM dbo.API " +
                                                        "INNER JOIN dbo.ControllerAPI ON dbo.API.idApi = dbo.ControllerAPI.apiID " +
                                                        "INNER JOIN dbo.EndPoints ON dbo.ControllerAPI.idController = dbo.EndPoints.controllerID ");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
