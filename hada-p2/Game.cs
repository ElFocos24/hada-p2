using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada
{
    namespace Hada
    {
        public class Barco
        {
            public Dictionary<Coordenada, string> CoordenadasBarco { get; private set; }
            public string Nombre { get; set; }
            public int NumDanyos { get; set; }

            public event EventHandler<TocadoArgs> eventoTocado;
            public event EventHandler<HundidoArgs> eventoHundido;

            public Barco(string nombre, int longitud, char orientacion, Coordenada coordenadaInicio)
            {
                this.Nombre = nombre;
                this.NumDanyos = 0;
                this.CoordenadasBarco = new Dictionary<Coordenada, string>();

                for (int i = 0; i < longitud; i++)
                {
                    Coordenada nuevaCoordenada;
                    if (orientacion == 'h')
                    {
                        nuevaCoordenada = new Coordenada(coordenadaInicio.Fila, coordenadaInicio.Columna + i);
                    }
                    else
                    {
                        nuevaCoordenada = new Coordenada(coordenadaInicio.Fila + i, coordenadaInicio.Columna);
                    }

                    this.CoordenadasBarco.Add(nuevaCoordenada, this.Nombre);
                }
            }

            public void Disparo(Coordenada c)
            {
                if (this.CoordenadasBarco.ContainsKey(c))
                {
                    if (this.CoordenadasBarco[c] == this.Nombre)
                    {
                        this.CoordenadasBarco[c] += "_T";

                        eventoTocado?.Invoke(this, new TocadoArgs { nombre = this.Nombre, coordenadaImpacto = c });

                        this.NumDanyos++;

                        if (this.hundido())
                        {
                            eventoHundido?.Invoke(this, new HundidoArgs { nombre = this.Nombre });
                        }
                    }
                }
            }

            public bool hundido()
            {
                foreach (var etiqueta in this.CoordenadasBarco.Values)
                {
                    if (etiqueta == this.Nombre)
                    {
                        return false;
                    }
                }
                return true;
            }

            public override string ToString()
            {
                string resultado = $"[{this.Nombre}] - DAÑOS: [{this.NumDanyos}] - HUNDIDO: [{this.hundido()}] - COORDENADAS: ";

                List<string> coordenadasList = new List<string>();
                foreach (var elemento in this.CoordenadasBarco)
                {
                    coordenadasList.Add($"[{elemento.Key.ToString()} :{elemento.Value}]");
                }

                resultado += string.Join(" ", coordenadasList);

                return resultado;
            }
        }
    }
}
