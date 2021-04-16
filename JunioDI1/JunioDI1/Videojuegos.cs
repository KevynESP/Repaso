using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JunioDI1
{
    class Videojuegos
    {
        public List<Videojuego> videojuegos = new List<Videojuego>();

        public int Posicion(int año)
        {
            for (int i = 0; i < videojuegos.Count; i++)
            {
                if (año <= videojuegos[i].Año)
                {
                    return i;
                }
            }
            return videojuegos.Count;
        }

        
        public bool Eliminar(int max, int min = 0)
        {
            bool puede = true;
            if (min>=0 && min < videojuegos.Count && max < videojuegos.Count && max >= 0)
            {
                puede = true;
                for (int i = max; i >= min; i--)
                {
                    //if (i <= max && i >= min)
                    {
                        videojuegos.RemoveAt(i);
                    }
                }
            }
            else
            {
                puede = false;
                Console.WriteLine("Fuera de rango");
            }
            
            return puede;
        }

        public List<Videojuego> Busqueda(Videojuego.eEstilo estilo)
        {
            List<Videojuego> estilosos = new List<Videojuego>();
            foreach (Videojuego item in videojuegos)
            {
                if (item.Estilo == estilo)
                {
                    estilosos.Add(item);
                }
            }
            return estilosos;
        }
    }
}
