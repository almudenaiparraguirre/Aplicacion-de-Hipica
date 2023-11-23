using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Aplicacion_de_Hipica_Almudena_Iparraguirre
{
    /// <summary>
    /// Lógica de interacción para MenuHorizontalSuperior.xaml
    /// </summary>
    public partial class MenuHorizontalSuperior : UserControl {

        private SolidColorBrush _textBlockColor = new SolidColorBrush(Colors.Black);

        public MenuHorizontalSuperior()
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

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //loginPopup.IsOpen = true;
            InicioSesion inicioSesion = new InicioSesion();
            Window.GetWindow(this).Close();
            inicioSesion.Show();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void inicio_click(object sender, MouseButtonEventArgs e)
        {
            MainWindow main = new MainWindow();
            Window.GetWindow(this).Close();
            main.Show();
        }

        private void novedades_click(object sender, MouseButtonEventArgs e)
        {
            Novedades main = new Novedades();
            Window.GetWindow(this).Close();
            main.Show();
        }

        private void quienesSomosClick(object sender, MouseButtonEventArgs e)
        {
            QuienesSomos main = new QuienesSomos();
            Window.GetWindow(this).Close();
            main.Show();
        }

        private void tienda_click(object sender, MouseButtonEventArgs e)
        {
            Tienda tienda = new Tienda();
            Window.GetWindow(this).Close();
            tienda.Show();
        }

        private void precios_click(object sender, MouseButtonEventArgs e)
        {
            Precios precios = new Precios();
            Window.GetWindow(this).Close();
            precios.Show();
        }

        private void galeria_click(object sender, MouseButtonEventArgs e)
        {
            Galeria galeria = new Galeria();
            Window.GetWindow(this).Close();
            galeria.Show();
        }
    }
}
