﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NabWeb
{
    class Url
    {
        String pagina;
        int veces;
        DateTime fecha;

        public string Pagina { get => pagina; set => pagina = value; }
        public int Veces { get => veces; set => veces = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
    }
}
