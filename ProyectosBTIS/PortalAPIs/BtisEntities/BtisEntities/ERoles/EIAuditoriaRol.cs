using BtisEntities.EUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtisEntities.ERoles
{
    public class EIAuditoriaRol
    {
        public int IdAuditoriaRol { get; set; }

        public int? IdRol { get; set; }
        public string? NombreRol { get; set; }
        public string? DescripcionRol { get; set; }

        public string? CorreoUsuario { get; set; }
        public string? NombreUsuario { get; set; }

        public string Accion { get; set; }
        public DateTime FechaAccion { get; set; }
    }
}
