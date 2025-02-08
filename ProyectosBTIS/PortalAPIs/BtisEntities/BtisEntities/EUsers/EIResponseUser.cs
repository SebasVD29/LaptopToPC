using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtisEntities.EUsers
{
    public class EIResponseUser 
    {
        public string Token { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Rol { get; set; }
  
        public EIResponseUser(EIUsers user, string token)
        {
            IdUsuario = user.IdUsuario;
            Nombre = user.NombreCompleto;
            Correo = user.CorreoElectronico;
            Rol = user.Rol;
            Token = token;
        }

        
         //public EIUsers usuario { get; set; } = new EIUsers();
         //public ResponseModel errores { get; set; } = new ResponseModel();
        
        

    }
}
