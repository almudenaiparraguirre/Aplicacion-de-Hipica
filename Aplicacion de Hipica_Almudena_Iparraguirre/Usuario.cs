using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_de_Hipica_Almudena_Iparraguirre
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string FotoPerfil { get; set; }
        // Otros datos relevantes

        public Usuario(int id, string nombreUsuario, string fotoPerfil)
        {
            Id = id;
            NombreUsuario = nombreUsuario;
            FotoPerfil = fotoPerfil;
            // Inicializar otros datos según sea necesario
        }
    }
}
