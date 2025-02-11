using BtisEntities.EUsers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtisDataAccess.DAUsers
{
    public class DAUsuarios
    {
        readonly DBConnection _DBConnection = new DBConnection();

        #region PublicMethods
        public int GetIdUserCorreo(String correo)
        {
            try
            {
                int _IdUsuario;
                using (SqlConnection _conn = new SqlConnection(_DBConnection.DBConnectionApis))
                {
                    _conn.Open();

                    using SqlCommand _cmd = new SqlCommand();
                    _cmd.Connection = _conn;
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.CommandText = "PA_Revisar_Usuario_Portal_Clientes_MFA";

                    _cmd.Parameters.AddWithValue("@Correo", Convert.ToString(correo));
                    _cmd.Parameters.Add("@IdUsuario", SqlDbType.BigInt);
                    _cmd.Parameters["@IdUsuario"].Direction = ParameterDirection.Output;
                    _cmd.ExecuteNonQuery();
                    _IdUsuario = Convert.ToInt32(_cmd.Parameters["@IdUsuario"].Value);
                }

                return _IdUsuario;
            }
            catch (Exception)
            {
                //envia el error a un capa superior
                throw;
            }
        }
        public EIUsers GetUserChecked(int IdUsuario)
        {
            try
            {
                EIUsers _EIUsers = new EIUsers();
                using (SqlConnection _conn = new SqlConnection(_DBConnection.DBConnectionApis))
                {
                    _conn.Open();

                    using SqlCommand _cmd = new SqlCommand();
                    _cmd.Connection = _conn;
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.CommandText = "PA_Obtener_Usuario_Portal_Clientes";

                    _cmd.Parameters.AddWithValue("@IdUsuario", Convert.ToString(IdUsuario));

                    SqlDataReader DsReader = _cmd.ExecuteReader();

                    if (DsReader.Read())
                    {
                        _EIUsers = LoadUsers(DsReader);
                    }
                }
                return _EIUsers;

            }
            catch (Exception) 
            {
                //envia el error a un capa superior
                throw;
            }
        }

        #endregion

        #region PrivateMethods
        private EIUsers LoadUsers(IDataReader ReadyUsers)
        {
            return new EIUsers
            {
                IdUsuario = Convert.ToInt32(ReadyUsers["IdUsuario"]),
                NombreCompleto = Convert.ToString(ReadyUsers["NombreCompleto"]),
                CorreoElectronico = Convert.ToString(ReadyUsers["CorreoElectronico"]),
                Rol = Convert.ToString(ReadyUsers["Rol"]),
             
            };
        }

        #endregion

    }

}
