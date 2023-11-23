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

namespace Aplicacion_de_Hipica_Almudena_Iparraguirre
{
    /// <summary>
    /// Lógica de interacción para RestablecerContrasena.xaml
    /// </summary>
    public partial class RestablecerContrasena : Window
    {
        public RestablecerContrasena()
        {
            InitializeComponent();
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
    }
}
