using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apicds.ViewModels
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string NombreCliente { get; set; }
        public string Email { get; set; }
        public string NroDeIdentificacion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public string TemaInteres { get; set; }
        public string Estado { get; set; }
       
    }
}
