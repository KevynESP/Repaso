#define JUEGA
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JunioDI1
{
    class Class1
    {
        public static int numero()
        {
            bool num = false;
            string n1 = "";
            int valor;
            do
            {
                Console.WriteLine("Solo admite numeros");
                    n1 = Console.ReadLine();
                    num = int.TryParse(n1, out valor);
            } while (!num);
            return valor;
        }

        public static Videojuego crea()
        {
            Console.WriteLine("Nombre:");
            string tit1 = Console.ReadLine();
            Console.WriteLine("Año:");
            int año1 = numero();
            Console.WriteLine("Estilo:");
            Videojuego.eEstilo estilos1 = estilar();
            Videojuego video1 = new Videojuego(tit1, año1, estilos1);
            return video1;
        }
        public static Videojuego.eEstilo estilar()
        {
            bool hay1 = false;
            string est1 = "";
            do
            {
                for (int i = 0; i < Enum.GetNames(typeof(Videojuego.eEstilo)).Length; i++)
                {
                    Console.WriteLine(i + 1 + "." + Enum.GetNames(typeof(Videojuego.eEstilo))[i]);
                }
                try
                {
                    string estilo = Console.ReadLine();
                    est1 = estilo;
                    if (Convert.ToInt32(est1) >= 0 && Convert.ToInt32(est1) <= Enum.GetNames(typeof(Videojuego.eEstilo)).Length)
                    {
                        hay1 = true;
                    }
                    else
                    {
                        Console.WriteLine("Fuera de rango");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Fuera de rango");

                }
            } while (!hay1);
            return (Videojuego.eEstilo)Convert.ToInt32(est1);
        }
        static void Main(string[] args)
        {
            Videojuegos vdj = new Videojuegos();

#if JUEGA
            Videojuego v = new Videojuego("Apex Legends", 2017, Videojuego.eEstilo.Shootemup);
            Videojuego v1 = new Videojuego("COD", 1987, Videojuego.eEstilo.Shootemup);
            Videojuego v2 = new Videojuego("F1", 2020, Videojuego.eEstilo.Deportivo);

            vdj.videojuegos.Add(v1);
            vdj.videojuegos.Add(v);
            vdj.videojuegos.Add(v2);
#endif
            bool funcionando = true;
            do
            {
                Console.WriteLine("1.Insertar nuevo videojuego");
                Console.WriteLine("2.Eliminar videojuegos");
                Console.WriteLine("3.Visualizar toda la lista de videojuegos");
                Console.WriteLine("4.Visualizar un estilo");
                Console.WriteLine("5.Modificar un videojuego");
                Console.WriteLine("6.Salir del programa");
                string str = Console.ReadLine();

                switch (str)
                {
                    case "1":
                        if (vdj.videojuegos.Count != 0)
                        {

                            Videojuego vi1 = crea();
                            vdj.videojuegos.Insert(vdj.Posicion(vi1.Año), vi1);

                            Console.WriteLine("Formato invalido");
                        }
                        else
                        {
                            vdj.videojuegos.Add(v);
                        }
                        break;
                    case "2":
                        Console.WriteLine("numero mínimo");
                        int a = numero();
                        Console.WriteLine("numero máximo");
                        int b = numero();
                        for (int i = 0; i < vdj.videojuegos.Count; i++)
                        {
                            if (a > b)
                            {
                                if (i >= b && i <= a)
                                {
                                    Console.WriteLine(String.Format("titulo: {0,-15} año: {1,-5} estilo: {2,-10}", vdj.videojuegos[i].titulo, vdj.videojuegos[i].Año, vdj.videojuegos[i].Estilo));
                                }
                            }
                            if (b > a)
                            {
                                if (i >= a && i <= b)
                                {
                                    Console.WriteLine(String.Format("titulo: {0,-15} año: {1,-5} estilo: {2,-10}", vdj.videojuegos[i].titulo, vdj.videojuegos[i].Año, vdj.videojuegos[i].Estilo));
                                }
                            }
                        }
                        Console.WriteLine("Desea continuar?");
                        string c = Console.ReadLine();
                        if (c.ToUpper() == "Y")
                        {
                            if (b > a) { vdj.Eliminar(b, a); }
                            else
                            {
                                vdj.Eliminar(a, b);
                            }

                        }
                        break;
                    case "3":
                        for (int i = 0; i < vdj.videojuegos.Count; i++)
                        {
                            Console.WriteLine(String.Format("titulo: {0,-15} estilo: {1,-10} pos: {2,-3} ", vdj.videojuegos[i].titulo, vdj.videojuegos[i].Estilo, i));
                        }
                        break;
                    case "4":
                        Videojuego.eEstilo est = estilar();
                        foreach (Videojuego vi in vdj.Busqueda(est))
                        {
                            Console.WriteLine(String.Format("titulo: {0,-15} año: {1,-5} estilo: {2,-10}", vi.titulo, vi.Año, vi.Estilo));
                        }
                        break;
                    case "5":
                        try
                        {
                            Console.WriteLine("En que posicion está el juego que quiere modificar?");
                            int pos = Convert.ToInt32(Console.ReadLine());
                            Videojuego vi2 = crea();
                            vdj.videojuegos[pos] = vi2;
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("No existe juego en esa posición");
                        }
                        break;
                    case "6":
                        funcionando = false;
                        break;
                }
            } while (funcionando);
        }
    }
}
