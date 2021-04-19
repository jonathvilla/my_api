﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicds.Models;

namespace apicds.ViewModels
{
    public class AlquilerViewModel
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Clientes Cliente { get; set; }
        public DateTime FechaAlquiler { get; set; }
        public int ValorAlquiler { get; set; }
    }
}
