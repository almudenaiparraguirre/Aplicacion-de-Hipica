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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aplicacion_de_Hipica_Almudena_Iparraguirre
{
    /// <summary>
    /// Lógica de interacción para ProductItem.xaml
    /// </summary>
    public partial class ProductItem : UserControl
    {
        public ProductItem()
        {
            InitializeComponent();
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            HideOverlay();
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            ShowOverlay();
        }

        private void comprar_Click(object sender, RoutedEventArgs e)
        {
            HideOverlay();
        }

        public void ShowOverlay()
        {
            overlayGrid.Visibility = Visibility.Visible;

            DoubleAnimation fadeInAnimation = new DoubleAnimation();
            fadeInAnimation.From = 0;
            fadeInAnimation.To = 1;
            fadeInAnimation.Duration = TimeSpan.FromSeconds(0.5);
            overlayGrid.Visibility = Visibility.Visible;
            overlayGrid.BeginAnimation(Grid.OpacityProperty, fadeInAnimation);

            DoubleAnimation buttonFadeInAnimation = new DoubleAnimation();
            buttonFadeInAnimation.From = 0;
            buttonFadeInAnimation.To = 1;
            buttonFadeInAnimation.Duration = TimeSpan.FromSeconds(0.5);

            overlayGrid.Children.OfType<Button>().FirstOrDefault()?.BeginAnimation(Button.OpacityProperty, buttonFadeInAnimation);
        }

        public void HideOverlay()
        {
            DoubleAnimation fadeOutAnimation = new DoubleAnimation();
            fadeOutAnimation.From = 1;
            fadeOutAnimation.To = 0;
            fadeOutAnimation.Duration = TimeSpan.FromSeconds(0.5);

            overlayGrid.BeginAnimation(Grid.OpacityProperty, fadeOutAnimation);

            DoubleAnimation buttonFadeOutAnimation = new DoubleAnimation();
            buttonFadeOutAnimation.From = 1;
            buttonFadeOutAnimation.To = 0;
            buttonFadeOutAnimation.Duration = TimeSpan.FromSeconds(0.5);

            overlayGrid.Children.OfType<Button>().FirstOrDefault()?.BeginAnimation(Button.OpacityProperty, buttonFadeOutAnimation);

            overlayGrid.Visibility = Visibility.Hidden;
        }
    }
}
