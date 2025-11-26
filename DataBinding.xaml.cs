using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace WpfAppNuevo1
{
    public partial class DataBinding : Window
    {
        public ObservableCollection<Producto> ListaProductos { get; set; }
        public Producto productoSel { get; set; }

        // ✔ Ruta fija que tú pediste
        private readonly string rutaArchivo = "c:\\mvj\\REGISTROCAR.txt";

        public DataBinding()
        {
            InitializeComponent();
            ListaProductos = new ObservableCollection<Producto>();

            VerificarCarpeta();
            CargarDesdeArchivo();

            DataContext = this;
            lstBProductos.ItemsSource = ListaProductos;
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

            var lineas = File.ReadAllLines(rutaArchivo);

            foreach (string linea in lineas)
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
        private void GuardarEnArchivo()
        {
            using (StreamWriter sw = new StreamWriter(rutaArchivo))
            {
                foreach (var p in ListaProductos)
                {
                    sw.WriteLine($"{p.Nombre};{p.Precio};{p.Horario}");
                }
            }
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNomProd.Text;
            string horario = txtHorario.Text;

            if (!double.TryParse(txtNomPrecio.Text, out double precio))
            {
                MessageBox.Show("Precio inválido");
                return;
            }

            if (precio > 0 && nombre != "" && horario != "")
            {
                ListaProductos.Add(new Producto(nombre, precio, horario));

                GuardarEnArchivo();  
                txtNomProd.Clear();
                txtNomPrecio.Clear();
                txtHorario.Clear();
            }
            else
            {
                MessageBox.Show("Error en el ingreso de datos ;)");
            }
        }
        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            if (productoSel != null)
            {
                ListaProductos.Remove(productoSel);

                GuardarEnArchivo();

                txtNomProd.Clear();
                txtNomPrecio.Clear();
                txtHorario.Clear();
            }
        }

        private void lstBProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (productoSel != null)
            {
                txtNomProd.Text = productoSel.Nombre;
                txtNomPrecio.Text = productoSel.Precio.ToString();
                txtHorario.Text = productoSel.Horario;
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            wpfwinpeincipal winP = new wpfwinpeincipal();
            winP.Show();
            this.Close();
        }
    }
}
