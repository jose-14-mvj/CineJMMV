using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppNuevo1
{
    public class Producto
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public string Horario { get; set; }

        public Producto()
        {
            Nombre = "no definido";
            Precio = 0.0;
            Horario = "sin horario";
        }

        public Producto(string nom, double pre, string hor)
        {
            this.Nombre = nom;
            this.Precio = pre;
            this.Horario = hor;
        }

        public string verDatos()
        {
            return $"{Nombre} {Precio} {Horario}";
        }
    }

}
