using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JunioDI1
{
    class Videojuego
    {
        public string titulo;
     
        public int Año { set; get; }
    
        private eEstilo estilo;
        public eEstilo Estilo
        {
            set { estilo = value; }
            get { return estilo; }
        }
        public enum eEstilo
        {
            Arcade=1, Videoaventura, Shootemup, Estrategia, Deportivo
        }

        public Videojuego(string titulo, int año, eEstilo estilo)
        {
            this.Año = año;
            this.titulo = titulo;
            this.estilo = estilo;
        }

    }
}
