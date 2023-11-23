using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Data.SqlClient;

namespace Aplicacion_de_Hipica_Almudena_Iparraguirre
{
    public partial class InicioSesion : Window
    {
        SqlConnection miConexionSql;

        public InicioSesion()
        {
            InitializeComponent();
            ActualizarInterfazUsuario();

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

        // Para obtener el contenido del TextBox
        private void ObtenerContenido()
        {
            string contenidoCorreo = correoTextBox.Text;
            string contenidoContrasena = contrasenaTextBox.Text;

            // Hacer algo con el contenido...
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

        private void restablecerContrasena(object sender, MouseButtonEventArgs e)
        {
            RestablecerContrasena restablecerContrasena = new RestablecerContrasena();
            this.Close();
            restablecerContrasena.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (VerificarCredenciales())
            {
                AppState.IsLoggedIn = true;
                ActualizarInterfazUsuario(); // Llama a ActualizarInterfazUsuario después de la autenticación
                this.Close();
            }
        }

        public void ActualizarInterfazUsuario()
        {
            // Actualiza la interfaz de usuario con la información del usuario
            if (App.CurrentUser != null)
            {
                // Actualiza la imagen del usuario en tu interfaz
                // Ejemplo: imageUsuario.Source = App.CurrentUser.UserImage;
            }
        }

        private bool VerificarCredenciales()
        {
            try
            {
                miConexionSql.Open();

                string usuario = correoTextBox.Text;
                string contrasena = contrasenaTextBox.Text;

                // Consulta SQL para verificar las credenciales
                string consulta = "SELECT COUNT(*) FROM datosHipica WHERE usuario = @usuario AND contrasena = @contrasena";

                using (SqlCommand cmd = new SqlCommand(consulta, miConexionSql))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@contrasena", contrasena);

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        // Credenciales válidas
                        MainWindow mainWindow = new MainWindow();
                        this.Close();
                        mainWindow.Show();
                        return true;
                    }
                    else
                    {
                        // Credenciales inválidas
                        MessageBox.Show("Correo electrónico o contraseña incorrectos.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar las credenciales: " + ex.Message);
                return false;
            }
            finally
            {
                miConexionSql.Close();
                App.CurrentUser.UserName = "Nombre de Usuario";
            }
        }
    }

    public static class AppState
    {
        public static bool IsLoggedIn { get; set; }
    }
}
