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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Text.RegularExpressions;

namespace WpfAppNuevo1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
        
    {
        private readonly string rutaArchLogin = "c:\\mvj\\REGISTRO.txt";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            string correo = txtCorreo.Text;
            string contra = txtPasword.Password;

            if (correo == "" || contra == "")
            {
                lblMensaje.Foreground = Brushes.Red;
                lblMensaje.Content = "Debe llenar TODOS los campos_ :(";
            }
            else
            {
                try {
                    if (!File.Exists(rutaArchLogin))
                    {
                        lblMensaje.Foreground = Brushes.Red;
                        lblMensaje.Content = "La ruta o el archivo no existen!!!!";
                        return;

                    }
                    else {
                        var contenidoArch = File.ReadAllLines(rutaArchLogin);
                        bool encontrado = false;
                        foreach (var linea in contenidoArch) {
                            var partes = linea.Split(',');
                            if (correo.Equals(partes[3]) && contra.Equals(partes[4]))
                            {
                                encontrado = true;
                                wpfwinpeincipal winP = new wpfwinpeincipal();
                                winP.Show();
                                this.Close();
                            }
                            else {
                                lblMensaje.Foreground = Brushes.Red;
                                lblMensaje.Content = "no esta registrado";
                            }
                        }
                            }
                }
                catch (Exception ex ) {
                    Console.WriteLine("ERROR:" + ex.Message);
                }
                //string datos = lblCorreo.Content.ToString() +



                //"\n" + "Contraseña:" + txtPasword.Password;
               // lblMensaje.Foreground = Brushes.Green;





            }


        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {

            txtCorreo.Text = "";
            txtPasword.Password = "";


        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            wpfNVen winSignUp = new wpfNVen();
            winSignUp.Show();
            this.Close();

        }
        private void txtCorreo_LostFocus(object sender, RoutedEventArgs e)
        {
            string emailPattern = "^[a-zA-Z0-9._%$]{3,}@[a-zA-Z0-9._-]{3,}.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(txtCorreo.Text, emailPattern))
            {
                lblMensaje.Foreground = Brushes.Red;
                lblMensaje.Content = "Correo no válido";
                txtCorreo.Text = "";
            }
        }
        private void txtPasword_LostFocus(object sender, RoutedEventArgs e)

        {

            string pwdPattern = "^[a-zA-Z0-9.#]{8,16}$";

            if (!Regex.IsMatch(txtPasword.Password, pwdPattern))

            {

                lblMensaje.Foreground = Brushes.Red;

                lblMensaje.Content = "Contraseña no válido";

                txtPasword.Password = "";

            }

        }

        

        private void btnVerC_Click_1(object sender, RoutedEventArgs e)
        {
            BienvenidaUsuario ver = new BienvenidaUsuario();
            ver.Show();
            this.Close();
        }
    }
}
