using BtisEntities.EUsers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;


namespace BetisWebAPIPortalApis
{
    public class ResponseMessage : Controller
    {
        public IActionResult Credenciales_Incorrectas()
        {
            return Ok(new { msg = "Credenciales Incorrectas", success = false });
        }
        public IActionResult Imposible_Ejecutar()
        {
            return BadRequest(new { msg = "Imposible ejecutar su transacción", success = false });
        }
        public IActionResult Imposible_Ejecutar_Exception(string Exception)
        {
            return BadRequest(new { msg = "Imposible ejecutar su transacción", errortype = Exception, success = false });
        }
        public IActionResult OK_EIuser(EIResponseUser _EIResponseUser)
        {
            return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = _EIResponseUser.usuario, success = true }));
        }
        public IActionResult StatusOk_General(string mensaje, bool status)
        {
            return Ok(new { msg = mensaje, success = status });
        }

        //public IActionResult OK_EICentro_Costo(EICentroCosto _EICentro_Costo)
        //{
        //    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { _EICentro_Costo, success = true }));
        //}

        //public IActionResult OK_EICentro_CostoList(List<EICentroCosto> _EICentro_CostoList)
        //{
        //    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { _EICentro_CostoList, success = true }));
        //}

        //public IActionResult OK_EIResponseRolesMenu(List<EIResponseRolesMenu> _EIResponseRolesMenu)
        //{
        //    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { _EIResponseRolesMenu, success = true }));
        //}

        public IActionResult Imposible_Ejecutar_General(string mensaje)
        {
            return BadRequest(new { msg = mensaje, success = false });
        }
    }
}
