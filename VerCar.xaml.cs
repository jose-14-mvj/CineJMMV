using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfAppNuevo1
{
    /// <summary>
    /// Lógica de interacción para VerCar.xaml
    /// </summary>
    public partial class VerCar : Window
    {
        public ObservableCollection<Producto> ListaProductos { get; set; }
        public Producto productoSel { get; set; }

        // Archivo donde se guardan los datos
        private readonly string rutaArchivo = "c:\\mvj\\REGISTROCAR.txt";

        public VerCar()
        {
            InitializeComponent();

            ListaProductos = new ObservableCollection<Producto>();

            VerificarCarpeta();
            CargarDesdeArchivo();

            DataContext = this;   // 🔥 Esto conecta XAML con C#
        }

        private void VerificarCarpeta()
        {
            string carpeta = "c:\\mvj";

            if (!Directory.Exists(carpeta))
                Directory.CreateDirectory(carpeta);
        }

        private void CargarDesdeArchivo()
        {
            if (!File.Exists(rutaArchivo))
                return;

            foreach (string linea in File.ReadAllLines(rutaArchivo))
            {
                if (string.IsNullOrWhiteSpace(linea)) continue;

                var datos = linea.Split(';');

                if (datos.Length < 3) continue;

                string nombre = datos[0];
                double precio = double.Parse(datos[1]);
                string horario = datos[2];

                ListaProductos.Add(new Producto(nombre, precio, horario));
            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MP = new MainWindow();
            MP.Show();
            this.Close();
        }
    }
}
