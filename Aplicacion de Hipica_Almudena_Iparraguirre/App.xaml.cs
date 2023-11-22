using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Aplicacion_de_Hipica_Almudena_Iparraguirre
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Usuario UsuarioActual { get; set; }

        // Método para cargar la información del usuario desde la base de datos al iniciar sesión
        public static void IniciarSesion(int usuarioId)
        {
            // Lógica para cargar información del usuario desde la base de datos
            //UsuarioActual = ObtenerUsuarioDesdeBaseDeDatos(usuarioId);
        }
    }
}
