using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
    public partial class MainWindow : Window
    {
        private LoginViewModel loginViewModel;
        public MainWindow()
        {
            InitializeComponent();
            loginViewModel = new LoginViewModel();

            // Establece el DataContext para que los enlaces funcionen
            this.DataContext = loginViewModel;

            // Maneja el cambio en la propiedad IsLoggedIn
            loginViewModel.PropertyChanged += LoginViewModel_PropertyChanged;
        }

        private void LoginViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Maneja el cambio en la propiedad IsLoggedIn
            if (e.PropertyName == nameof(loginViewModel.IsLoggedIn))
            {
                // Actualiza la interfaz según el estado de inicio de sesión
                ActualizarInterfaz();
            }
        }

        private void ActualizarInterfaz()
        {
            if (loginViewModel.IsLoggedIn)
            {
                loginImage.Source = loginViewModel.LoginImage;
                miniMenu.Visibility = Visibility.Visible;
            }
            else
            {
                loginImage.Source = null;
                miniMenu.Visibility = Visibility.Collapsed;
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (AppState.IsLoggedIn)
            {
                miniMenu.Visibility = Visibility.Visible;
            }
        }

        private void Calendario_Click(object sender, RoutedEventArgs e)
        {
            Calendario calendario = new Calendario();
            this.Close();
            calendario.Show();
        }

        private void FichaAlumno_Click(object sender, RoutedEventArgs e)
        {
            FichaAlumno ficha = new FichaAlumno();
            this.Close();
            ficha.Show();
        }

        private void videoYoutube(object sender, MouseButtonEventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?time_continue=1&v=aTAVOGEjLxE&embeds_referring_euri=https%3A%2F%2Fgesthip.com%2F&source_ve_path=Mjg2NjY&feature=emb_logo");
        }
    }
}
