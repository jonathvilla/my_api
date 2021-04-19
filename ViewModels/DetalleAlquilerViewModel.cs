using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicds.Models;


namespace apicds.ViewModels
{
    public class DetalleAlquilerViewModel
    {
        public int Id { get; set; }
        public int CdId { get; set; }
        public CD CD { get; set; }
        public int AlquilerId { get; set; }
        public Alquiler Alquiler { get; set; }
        public int DiasPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
    }
}
