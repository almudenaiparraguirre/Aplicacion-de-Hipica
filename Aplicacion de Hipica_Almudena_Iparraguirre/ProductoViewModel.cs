using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_de_Hipica_Almudena_Iparraguirre
{
    public class ProductoViewModel : INotifyPropertyChanged
    {
        private string _nombre;
        private string _imagen;
        private decimal _precio;
        private string _descripcion;

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (_nombre != value)
                {
                    _nombre = value;
                    OnPropertyChanged(nameof(Nombre));
                }
            }
        }

        public string Imagen
        {
            get { return _imagen; }
            set
            {
                if (_imagen != value)
                {
                    _imagen = value;
                    OnPropertyChanged(nameof(Imagen));
                }
            }
        }

        public decimal Precio
        {
            get { return _precio; }
            set
            {
                if (_precio != value)
                {
                    _precio = value;
                    OnPropertyChanged(nameof(Precio));
                }
            }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set
            {
                if (_descripcion != value)
                {
                    _descripcion = value;
                    OnPropertyChanged(nameof(Descripcion));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
