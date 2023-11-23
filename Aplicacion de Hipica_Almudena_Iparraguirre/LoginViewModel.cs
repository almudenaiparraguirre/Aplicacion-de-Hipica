using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Aplicacion_de_Hipica_Almudena_Iparraguirre
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private bool isLoggedIn;
        private BitmapImage loginImage;

        public bool IsLoggedIn
        {
            get { return isLoggedIn; }
            set
            {
                if (isLoggedIn != value)
                {
                    isLoggedIn = value;
                    NotifyPropertyChanged();
                    UpdateLoginImage();
                }
            }
        }

        public BitmapImage LoginImage
        {
            get { return loginImage; }
            set
            {
                if (loginImage != value)
                {
                    loginImage = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public LoginViewModel()
        {
            // Inicializa el ViewModel con la información de inicio de sesión
            IsLoggedIn = AppState.IsLoggedIn;
        }

        private void UpdateLoginImage()
        {
            // Lógica para cambiar la imagen del login en función del estado de inicio de sesión
            if (IsLoggedIn)
            {
                // Lógica para cargar una imagen aleatoria cuando la sesión está iniciada
                // Puedes utilizar aquí tu propia lógica para cargar una imagen aleatoria
                // Ejemplo:
                var randomImage = GetRandomLoginImage();
                //LoginImage = new BitmapImage(new Uri(randomImage));
            }
            else
            {
                // Lógica para cargar la imagen predeterminada cuando la sesión no está iniciada
                LoginImage = new BitmapImage(new Uri("RutaImagenPredeterminada"));
            }
        }

        private string GetRandomLoginImage()
        {
            // Lógica para obtener una imagen aleatoria
            // Retorna la ruta de la imagen aleatoria
            // Ejemplo:
            List<string> randomImages = new List<string>
            {
                "images/fotoGaleria1.jpg",
                "images/fotoGaleria2.jpg"
            };

            Random random = new Random();
            int index = random.Next(randomImages.Count);

            return randomImages[index];
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
