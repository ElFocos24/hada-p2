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
        //Atributo fila
        private int _fila; //Campo de respaldo

        public int Fila
        {
            //Implementamos las propiedades publicas
            get { return _fila; }
            set
            {
                //Implementamos un validador para cumplir con el enunciado
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

        //Atributo columna
        private int _columna; //Campo de respaldo

        public int Columna
        {
            get { return _columna; }
            set
            {
                //Implementamos un validador para cumplir con el enunciado
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

        
        public Coordenada() //Constructor por defecto
        {
            Fila = 0;
            Columna = 0;
        }

        public Coordenada(int fila, int columna) //Constructor - param : int, int
        {
            Fila = fila;
            Columna = columna;
        }

        public Coordenada(string fila, string columna) //Constructor - param : string, string
        {
            Fila = int.Parse(fila);
            Columna = int.Parse(columna);
        }

        public Coordenada(Coordenada coordenada) //Constructor de copia
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
            //Si el objeto es una coordenada, entonces llamamos al método que las compara
            if (obj is Coordenada other)
            {
                return Equals(other);
            }
            return false;
        }

        public bool Equals(Coordenada other)
        {
            // Si es null, no puede ser igual
            if (other is null) return false;

            // Comparación por valor
            return this.Fila == other.Fila && this.Columna == other.Columna;
        }

    }
}
