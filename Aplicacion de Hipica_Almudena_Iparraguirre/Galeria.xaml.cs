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
    /// Lógica de interacción para Galeria.xaml
    /// </summary>
    public partial class Galeria : Window
    {

        private List<string> imagenes = new List<string>
        {
            "images/fotoGaleria1.jpg",
            "images/fotoGaleria2.jpg"
        };

        private int indiceActual = 0;

        public Galeria()
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

        }

        private void imagen_click(object sender, MouseButtonEventArgs e)
        {

        }

        private void flechaizquierda_click(object sender, MouseButtonEventArgs e)
        {
            CambiarImagen(-1);
        }

        private void flechaderecha_click(object sender, MouseButtonEventArgs e)
        {
            CambiarImagen(1);
        }

        private void CambiarImagen(int cambio)
        {
            indiceActual += cambio;

            // Asegúrate de no salir de los límites de la lista de imágenes
            if (indiceActual < 0)
                indiceActual = imagenes.Count - 1;
            else if (indiceActual >= imagenes.Count)
                indiceActual = 0;

            MostrarImagenActual();
        }

        private void MostrarImagenActual()
        {
            mainImage.Source = new BitmapImage(new System.Uri(imagenes[indiceActual], System.UriKind.Relative));
        }
    }
}
