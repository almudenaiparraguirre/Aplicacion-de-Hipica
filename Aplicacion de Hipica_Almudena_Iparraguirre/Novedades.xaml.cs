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
    /// Lógica de interacción para Novedades.xaml
    /// </summary>
    public partial class Novedades : Window
    {
        public Novedades()
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

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = (TextBlock)sender;

            if (textBlock != null)
            {
                Clipboard.SetText(textBlock.Text);
                MessageBox.Show("Texto copiado al portapapeles: " + textBlock.Text);
            }
        }

        private void mainWindow_click(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void quienesSomos_click(object sender, MouseButtonEventArgs e)
        {
            QuienesSomos quienesSomos = new QuienesSomos();
            this.Close();
            quienesSomos.Show();
        }

        private void tienda_click(object sender, MouseButtonEventArgs e)
        {
            Tienda tienda = new Tienda();
            this.Close();
            tienda.Show();
        }
    }
}
