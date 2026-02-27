using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hada;

namespace Hada
{
    public class TocadoArgs : EventArgs
    {
        public string nombre { get; }
        public Coordenada coordenadaImpacto { get; }

        public TocadoArgs(string nombre, Coordenada coordenadaImpacto)
        {
            this.nombre = nombre;
            this.coordenadaImpacto = coordenadaImpacto;
        }
    }

    public class HundidoArgs : EventArgs
    {
        public string nombre { get; }

        public HundidoArgs(string nombre)
        {
            this.nombre = nombre;
        }
    }
}