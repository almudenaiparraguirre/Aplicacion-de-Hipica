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
using System.Windows.Shapes;

namespace Aplicacion_de_Hipica_Almudena_Iparraguirre
{
    /// <summary>
    /// Lógica de interacción para Tienda.xaml
    /// </summary>
    public partial class Tienda : Window
    {
        public Tienda()
        {
            InitializeComponent();

        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is Producto producto)
            {
                MostrarDetallesProducto(producto);
            }
        }

        private void MostrarDetallesProducto(Producto producto)
        {
            Producto ventanaProducto = new Producto();
            ventanaProducto.DataContext = producto;
            ventanaProducto.Show();
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is ProductItem productItem)
            {
                productItem.ShowOverlay();
            }
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is ProductItem productItem)
            {
                productItem.HideOverlay();
            }
        }
    }
}
