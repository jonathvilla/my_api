using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicds.Response;
using apicds.ViewModels;
using apicds.Models;
using Microsoft.EntityFrameworkCore;

namespace apicds
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlquilerController : ControllerBase
    {
        public readonly Context _miBd;
        public AlquilerController(Context miBd)
        {
            _miBd = miBd;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var Lista = _miBd.alquilers.Include("Cliente").ToList();
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
        public IActionResult Add(AlquilerViewModel oAlquiler)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                Alquiler alquiler = new Alquiler();
                alquiler.ClienteId = oAlquiler.ClienteId;
                alquiler.FechaAlquiler = oAlquiler.FechaAlquiler;
                alquiler.ValorAlquiler = oAlquiler.ValorAlquiler;
                _miBd.alquilers.Add(alquiler);
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
        public IActionResult Update(AlquilerViewModel oAlquiler)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var alquiler = _miBd.alquilers.Find(oAlquiler.Id);
                alquiler.ClienteId = oAlquiler.ClienteId;
                alquiler.FechaAlquiler = oAlquiler.FechaAlquiler;
                alquiler.ValorAlquiler = oAlquiler.ValorAlquiler;
                _miBd.alquilers.Update(alquiler);
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
                var alquiler = _miBd.alquilers.Find(Id);
                _miBd.alquilers.Remove(alquiler);
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
