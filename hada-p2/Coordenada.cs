using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Hada
{
    public class Coordenada
    {
        private int _fila; //Campo de respaldo

        public int Fila
        {
            get { return _fila; }
            set
            {
                if (value < 0 || value > 9)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                else
                {
                    _fila = value;
                }
            }
        }

        private int _columna; //Campo de respaldo

        public int Columna
        {
            get { return _columna; }
            set
            {
                if (value < 0 || value > 9)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                else
                {
                    _columna = value;
                }
            }
        }

        public Coordenada()
        {
            Fila = 0;
            Columna = 0;
        }

        public Coordenada(int fila, int columna)
        {
            Fila = fila;
            Columna = columna;
        }

        public Coordenada(string fila, string columna) {
            Fila = int.Parse(fila);
            Columna = int.Parse(columna);
        }

        public Coordenada(Coordenada coordenada)
        {
            this.Fila = coordenada.Fila;
            this.Columna = coordenada.Columna;
        }

        public override string ToString()
        {
            return string.Concat("(",Fila,",",Columna,")");
        }

        public override int GetHashCode()
        {
            return this.Fila.GetHashCode()^this.Columna.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            // Si no es Coordenada, no es igual
            //if (obj is not Coordenada other) return false;

            // Reutiliza el Equals tipado
            //return Equals(other);
            return false; //Temporal <---
        }

        public bool Equals(Coordenada other)
        {
            // Si es null, no puede ser igual
            if (other is null) return false;

            // (Opcional) Si es la misma referencia en memoria, sí es igual
            if (ReferenceEquals(this, other)) return true;

            // Comparación por valor
            return this.Fila == other.Fila && this.Columna == other.Columna;
        }

    }
}
