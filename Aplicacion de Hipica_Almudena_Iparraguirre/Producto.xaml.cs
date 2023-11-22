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
    /// Lógica de interacción para Producto.xaml
    /// </summary>
    public partial class Producto : Window
    {
        public Producto()
        {
            InitializeComponent();
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

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void mainWindow_click(object sender, MouseButtonEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();
        }

        private void novedades_click(object sender, MouseButtonEventArgs e)
        {
            /*Novedades novedades = new Novedades();
            this.Close();
            novedades.Show();*/
        }

        private void precios_click(object sender, MouseButtonEventArgs e)
        {
            Precios precios = new Precios();
            this.Close();
            precios.Show();
        }

        private void galeriaClick(object sender, MouseButtonEventArgs e)
        {
            Galeria galeria = new Galeria();
            this.Close();
            galeria.Show();
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void quienesSomos_click(object sender, MouseButtonEventArgs e)
        {
            QuienesSomos quienes = new QuienesSomos();
            this.Close();
            quienes.Show();
        }
    }
}
