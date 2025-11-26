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
    /// Lógica de interacción para wpfwinpeincipal.xaml
    /// </summary>
    public partial class wpfwinpeincipal : Window
    {
        public wpfwinpeincipal()
        {
            InitializeComponent();
        }

        private void btnData_Click(object sender, RoutedEventArgs e)
        {
            DataBinding wins = new DataBinding();
            wins.Show();
            this.Close();
        }

        private void btnVerC_Click(object sender, RoutedEventArgs e)
        {
            VerCar ver= new VerCar();
            ver.Show();
            this.Close();   
        }
    }
}
