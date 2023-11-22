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
    public partial class MenuHorizontalSuperior : UserControl
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private string _estadoActual;
        public string EstadoActual
        {
            get { return _estadoActual; }
            set
            {
                if (_estadoActual != value)
                {
                    _estadoActual = value;
                    OnPropertyChanged(nameof(EstadoActual));
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MenuHorizontalSuperior()
        {
            InitializeComponent();
            DataContext = this; 
            ActualizarEstado();

            var mainWindow = Application.Current.MainWindow;
            if (mainWindow != null)
            {
                mainWindow.Activated += WindowActivated;
            }
        }

        private void ActualizarEstado()
        {
            var ventanaActual = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);

            if (ventanaActual != null)
            {
                EstadoActual = ventanaActual.GetType().Name == "Inicio" ? "Inicio" : "Otro";
            }
        }

        private void WindowActivated(object sender, EventArgs e)
        {
            ActualizarEstado();
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

        private void novedades_click(object sender, MouseButtonEventArgs e)
        {
            Novedades novedades = new Novedades();
            Window.GetWindow(this).Close();
            novedades.Show();
        }

        private void imagen_click(object sender, MouseButtonEventArgs e)
        {
            //loginPopup.IsOpen = true;
        }

        private void quienesSomosClick(object sender, MouseButtonEventArgs e)
        {
            QuienesSomos quienesSomos = new QuienesSomos();
            Window.GetWindow(this).Close();
            quienesSomos.Show();
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

        private void inicio_click(object sender, MouseButtonEventArgs e)
        {
            EstadoActual = "Inicio";
            MainWindow main = new MainWindow();
            Window.GetWindow(this).Close();
            main.Show();
        }
    }
}
