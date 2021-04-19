using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicds.Response;
using apicds.ViewModels;
using apicds.Models;

namespace apicds
{
    [Route("api/[controller]")]
    [ApiController]
    public class CDController : ControllerBase
    {
        public readonly Context _miBd;
        public CDController(Context miBd)
        {
            _miBd = miBd;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var Lista = _miBd.cd.ToList();
                oRespuesta.Exito = 1;
                oRespuesta.Datos = Lista;
            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        public IActionResult Add(CDViewModel oCd)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                CD Cd = new CD();
                Cd.Condicion = oCd.Condicion;
                Cd.ubicacion = oCd.ubicacion;
                Cd.Estado = oCd.Estado;
                
                _miBd.cd.Add(Cd);
                _miBd.SaveChanges();
                oRespuesta.Exito = 1;
            }

            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPut]
        public IActionResult Update(CDViewModel oCd)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var Cd = _miBd.cd.Find(oCd.Id);
                Cd.Condicion = oCd.Condicion;
                Cd.ubicacion = oCd.ubicacion;
                Cd.Estado = oCd.Estado;
                _miBd.cd.Update(Cd);
                _miBd.SaveChanges();
                oRespuesta.Exito = 1;
            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;
            }
            return Ok(oRespuesta);
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var Cd = _miBd.cd.Find(Id);
                _miBd.cd.Remove(Cd);
                _miBd.SaveChanges();
                oRespuesta.Exito = 1;
            }

            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;
            }
            return Ok(oRespuesta);
        }
    }
}
