using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtisEntities.EUsers
{
    public class EIResponseUser 
    {
        
         public EIUsers usuario { get; set; } = new EIUsers();
         public EIToken token { get; set; } = new EIToken();
         public EIResponseModel errores { get; set; } = new EIResponseModel();
        
    }
}
