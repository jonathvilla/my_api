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

namespace apicds.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleAlquilerController : ControllerBase
    {
        public readonly Context _miBd;
        public DetalleAlquilerController(Context miBd)
        {
            _miBd = miBd;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var Lista = _miBd.detalleAlquilers.Include("CD").Include("Alquiler").ToList();
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
        public IActionResult Add(DetalleAlquilerViewModel oDetalleAlquiler)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                DetalleAlquiler detalleAlquiler = new DetalleAlquiler();
                detalleAlquiler.CdId = oDetalleAlquiler.CdId;
                detalleAlquiler.AlquilerId = oDetalleAlquiler.AlquilerId;
                detalleAlquiler.DiasPrestamo = oDetalleAlquiler.DiasPrestamo;
                detalleAlquiler.FechaDevolucion = oDetalleAlquiler.FechaDevolucion;
                _miBd.detalleAlquilers.Add(detalleAlquiler);
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
        public IActionResult Update(DetalleAlquilerViewModel oDetalleAlquiler)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var detalleAlquiler = _miBd.detalleAlquilers.Find(oDetalleAlquiler.Id);
                detalleAlquiler.CdId = oDetalleAlquiler.CdId;
                detalleAlquiler.AlquilerId = oDetalleAlquiler.AlquilerId;
                detalleAlquiler.DiasPrestamo = oDetalleAlquiler.DiasPrestamo;
                detalleAlquiler.FechaDevolucion = oDetalleAlquiler.FechaDevolucion;
                _miBd.detalleAlquilers.Update(detalleAlquiler);
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
                var detalleAlquiler = _miBd.detalleAlquilers.Find(Id);
                _miBd.detalleAlquilers.Remove(detalleAlquiler);
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
