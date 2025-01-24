using API1.IDapper;
using API1.IServicios;
using API1.Modelo;
using Dapper;
using System.Data;

namespace API1.Servicios
{
    public class UsuarioServicios : IUsuarioServicios
    {
        private readonly IDapperContext _context;
        // inyectamos la interfaz de IDapperContext para poder obtener cadena de conexion en cada método
        public UsuarioServicios(IDapperContext context)
        {
            _context = context;
        }
        public async Task<int> Crear(Usuario usuario)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();

                param.Add("@nombre", usuario.NombreUno, DbType.String, ParameterDirection.Input);
                param.Add("@correo", usuario.CorreoUno, DbType.String, ParameterDirection.Input);
                param.Add("@password", usuario.PasswordUno, DbType.String, ParameterDirection.Input);

                using (var conn = _context.CrearConexion())
                {
                    var query = "INSERT INTO [BDExterna].[dbo].[Usuario] (NombreUno, CorreoUno, PasswordUno) OUTPUT INSERTED.IdExternoUno " +
                        " VALUES (@nombre, @correo, @password)";
                    var id = await conn.QuerySingleAsync<int>(query, param);
                    return id;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Usuario> Actualizar(Usuario usuario)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();

                param.Add("@nombre", usuario.NombreUno, DbType.String, ParameterDirection.Input);
                param.Add("@correo", usuario.CorreoUno, DbType.String, ParameterDirection.Input);
                param.Add("@password", usuario.PasswordUno, DbType.String, ParameterDirection.Input);
                param.Add("@id", usuario.IdExternoUno, DbType.Int32, ParameterDirection.Input);

                using (var conn = _context.CrearConexion())
                {
                    string query = "UPDATE [BDExterna].[dbo].[Usuario] SET NombreUno = @nombre, CorreoUno = @correo, PasswordUno = @password " +
                                    "WHERE IdExternoUno = @id";
                    await conn.ExecuteAsync(query, param);
                    return usuario;


                }

            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<IEnumerable<Usuario>> Listar()
        {
            try
            {
                
                using (var conn = _context.CrearConexion())
                {
                    return await conn.QueryAsync<Usuario>("Select * From [BDExterna].[dbo].[Usuario]");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Usuario> Obtener(int id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();

                param.Add("@id", id, DbType.Int32, ParameterDirection.Input);

                using (var conn = _context.CrearConexion())
                {
                    return await conn.QuerySingleOrDefaultAsync<Usuario>("Select * From [BDExterna].[dbo].[Usuario] WHERE IdExternoUno = @id", param);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
