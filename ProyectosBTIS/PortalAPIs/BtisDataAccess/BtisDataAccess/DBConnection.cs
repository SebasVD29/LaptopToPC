using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtisDataAccess
{
    internal class DBConnection
    {
   
            private static IConfiguration _configuration;

            public static void SetDBConfiguration(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public string DBConnectionApis
            {

                get { return _configuration.GetConnectionString("BtisConnectionCRM"); }

            }
            //public string DBConnectionReportes
            //{

            //    get { return _configuration.GetConnectionString("BtisConnectionReportes"); }
            //}
            //public string DBConnectionJDE
            //{

            //    get { return _configuration.GetConnectionString("JDEConnectionCRM"); }


            //}

            #region "Conexion"


            public string DBConecction()
            {
                string conexion;

                try
                {
                    conexion = DBConnectionApis;
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException(ex.Message);
                }
                return conexion;
            }
            public string GetConnection(bool usePAPIs)
            {
                try
                {
                    return DBConnectionApis;
                //if (useCRM)
                //{
                //    return DBConnectionCRM;
                //}
                //else
                //{
                //    //return DBConnectionJDE;
                //}
            }
                catch (Exception ex)
                {
                    throw new InvalidOperationException(ex.Message);
                }
            }
            public string GetConnectionString(string connectionName)
            {
                throw new NotImplementedException();
            }

            #endregion
        }


        public interface IDbConnection
        {
            string GetConnectionString(string connectionName);
        }
    
}
