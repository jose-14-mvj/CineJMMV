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
using System.IO;
using System.Text.RegularExpressions;


namespace WpfAppNuevo1
{
    /// <summary>
    /// Lógica de interacción para wpfNVen.xaml
    /// </summary>
    public partial class wpfNVen : Window
    {
        private readonly string rutaArchLogin = "c:\\mvj\\REGISTRO.txt";
        public wpfNVen()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            lblMensaje.Content = ""; 
            if ((txtNombre.Text == "" || txtAP.Text == "" || txtAM.Text == "" || txtCelular.Text == "" || txtFNacimiento.Text == "" || txtPasword.Password == ""))
            {
                lblMensaje.Foreground = Brushes.Red;
                lblMensaje.Content = "Debe llenar TODOS los campos :( ";
                return;
            }

            string letterPattern = "^[a-zA-ZáéíóúÁÉÍÓÚñÑ]+$";
           string numPattern = "^[0-9]{8,16}$";
            string pwdPattern = "^[a-zA-Z0-9.#]{8,16}$";

            string campoInvalido = "";

            switch (true)
            {
                case true when !Regex.IsMatch(txtNombre.Text, letterPattern):
                    campoInvalido = "Nombre";
                    txtNombre.Clear();
                    txtNombre.Focus();
                    break;

                case true when !Regex.IsMatch(txtAP.Text, letterPattern):
                    campoInvalido = "Apellido Paterno";
                    txtAP.Clear();
                    txtAP.Focus();
                    break;

                case true when !Regex.IsMatch(txtAM.Text, letterPattern):
                    campoInvalido = "Apellido Materno";
                    txtAM.Clear();
                    txtAM.Focus();
                    break;

                case true when !Regex.IsMatch(txtCelular.Text, numPattern):
                    campoInvalido = "Celular";
                    txtCelular.Clear();
                    txtCelular.Focus();
                    break;
                case true when !Regex.IsMatch(txtPasword.Password, pwdPattern):
                    campoInvalido = "Password";
                    txtPasword.Clear();
                    txtPasword.Focus();
                    break;
            }

           
            
            if (!string.IsNullOrEmpty(campoInvalido))
            {
             lblMensaje.Foreground = Brushes.Red;
             lblMensaje.Content = $"El formato del {campoInvalido} es incorrecto";
             return;
            }

            
            string correo = $"{txtNombre.Text[0].ToString().ToLower()}{txtAP.Text.ToLower()}{txtAM.Text.ToLower()[0]}@univalle.edu";

            string datos = txtNombre.Text +" "+
                  txtAP.Text + " "+ txtAM.Text +","+
                   txtCelular.Text +","+
                   txtFNacimiento.Text +","
                   + correo + ","+txtPasword.Password + "\n";

            File.AppendAllText(rutaArchLogin, datos, Encoding.UTF8);
            lblMensaje.Foreground = Brushes.Green;
            lblMensaje.Content = $"Bienvenido/a {txtNombre.Text} {txtAP.Text} {txtAM.Text}! :)";

            wpfwinpeincipal principal = new wpfwinpeincipal();
            principal.Show();
            this.Close();
        }



        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtPasword.Password = "";
            txtFNacimiento.Text = "";
            txtCelular.Text = "";
            txtAM.Text = "";
            txtAP.Text = "";

        }

       
    }
}
