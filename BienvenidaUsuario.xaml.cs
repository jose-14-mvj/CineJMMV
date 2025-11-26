using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para BienvenidaUsuario.xaml
    /// </summary>
    public partial class BienvenidaUsuario : Window
    {
        public BienvenidaUsuario()
        {
            InitializeComponent();
        }

        private void btnVerC_Click(object sender, RoutedEventArgs e)
        {
            VerCar ver = new VerCar();
            ver.Show();
            this.Close();
        }

        private void btnData_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://jose-14-mvj.github.io/index/",
                UseShellExecute = true
            });
        }
    }
}
