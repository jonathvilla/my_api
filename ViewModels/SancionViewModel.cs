using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicds.Models;

namespace apicds.ViewModels
{
    public class SancionViewModel
    {
        public int Id { get; set; }       
        public int AlquilerId { get; set; }
        public Alquiler Alquiler { get; set; }
        public string TipoSancion { get; set; }
        public int NroDiasSancion { get; set; }
    }
}
