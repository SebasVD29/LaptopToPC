using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtisEntities.EUsers
{
    public class EIUsers
    {
        
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string CorreoElectronico { get; set; }
        public string NombreRol { get; set; }

        public String token { get; set; }

    }
}
