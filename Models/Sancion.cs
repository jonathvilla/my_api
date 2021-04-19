using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apicds.Models
{
    public class Sancion
    {
        public int Id { get; set; }
        public int AlquilerId { get; set; }
        public Alquiler Alquiler { get; set; }
        public string TipoSancion{ get; set; }
        public int NroDiasSancion { get; set; }
               
    }
}
