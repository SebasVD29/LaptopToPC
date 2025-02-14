using BtisEntities.ERoles;
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
      
        public EIUsers Get_User_Checked(String correo)
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
                    _cmd.CommandText = "Usuario.ValidarUsuarioMFA";
                    _cmd.Parameters.AddWithValue("@Correo", Convert.ToString(correo));
                    SqlDataReader DsReader = _cmd.ExecuteReader();

                    if (DsReader.Read())
                    {
                        _EIUsers = LoadUsers(DsReader);
                    }

                    _conn.Close();
                }
                return _EIUsers;

            }
            catch (Exception) 
            {
                //envia el error a un capa superior
                throw;
            }
        }
        public bool Exist_Rol_In_User(string nombreRol)
        {
            try
            {
                bool existeRolUsuario;
                using SqlConnection _conn = new SqlConnection(_DBConnection.DBConnectionApis);
                _conn.Open();

                using SqlCommand _cmd = new SqlCommand();
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = "AP_";
                _cmd.Parameters.AddWithValue("@NombreRol", Convert.ToString(nombreRol));
                _cmd.Parameters.Add("@Resultado", 0);
                _cmd.Parameters["@Resultado"].Direction = ParameterDirection.Output;
             
                _cmd.ExecuteNonQuery();
                existeRolUsuario = Convert.ToBoolean(_cmd.Parameters["@Resultado"].Value);
                
                return existeRolUsuario;
            }
            catch (Exception)
            {
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
                NombreUsuario = Convert.ToString(ReadyUsers["NombreUsuario"]),
                CorreoElectronico = Convert.ToString(ReadyUsers["CorreoElectronico"]),
                NombreRol = Convert.ToString(ReadyUsers["NombreRol"]),

            };
        }

        #endregion

    }

}
