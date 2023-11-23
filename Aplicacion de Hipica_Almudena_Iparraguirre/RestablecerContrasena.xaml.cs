using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

namespace Aplicacion_de_Hipica_Almudena_Iparraguirre
{
    /// <summary>
    /// Lógica de interacción para RestablecerContrasena.xaml
    /// </summary>
    public partial class RestablecerContrasena : Window
    {
        SqlConnection miConexionSql;
        public RestablecerContrasena()
        {
            InitializeComponent();
            try
            {
                string miConexion = ConfigurationManager.ConnectionStrings["Aplicacion_de_Hipica_Almudena_Iparraguirre.Properties.Settings.AplicacionDeHipicaConnectionString"].ConnectionString;

                if (miConexion == null)
                {
                    throw new ArgumentNullException("La cadena de conexión es nula.");
                }

                miConexionSql = new SqlConnection(miConexion);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar la conexión: {ex.Message}");
            }
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;

            if (textBlock != null)
            {
                textBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B71C1C"));
            }
        }

        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;

            if (textBlock != null)
            {
                textBlock.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (textBox.Text == "Correo Electrónico" || textBox.Text == "Contraseña")
                {
                    textBox.Text = "";
                    textBox.Foreground = Brushes.Black; // O el color que desees cuando se está escribiendo
                }
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = textBox.Name == "correoTextBox" ? "Correo Electrónico" : "Contraseña";
                    textBox.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6B6B6B")); // O el color original
                }
            }
        }

        private void volverInicioSesion(object sender, MouseButtonEventArgs e)
        {
            InicioSesion inicioSesion = new InicioSesion();
            this.Close();
            inicioSesion.Show();
        }

        private bool VerificarUsuario()
        {
            try
            {
                miConexionSql.Open();

                string usuario = correoTextBox.Text;

                // Consulta SQL para verificar si el usuario existe
                string consulta = "SELECT COUNT(*) FROM datosHipica WHERE usuario = @usuario";

                using (SqlCommand cmd = new SqlCommand(consulta, miConexionSql))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        // Usuario existe
                        return true;
                    }
                    else
                    {
                        // Usuario no existe
                        MessageBox.Show("No se encontró ningún usuario con la dirección de correo electrónico proporcionada.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar el usuario: " + ex.Message);
                return false;
            }
            finally
            {
                miConexionSql.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (VerificarUsuario())
            {
                MessageBox.Show("Se ha enviado un enlace para restablecer la contraseña al correo electrónico proporcionado.");
                InicioSesion inicioSesion = new InicioSesion();
                this.Close();
                inicioSesion.Show();
            }
        }
    }
}
