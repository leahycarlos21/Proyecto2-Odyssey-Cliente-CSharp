using Prueba.TCPCliente;
using Prueba.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Prueba.ConexionCliente
{
    public class AddDatoMensaje : Mensajes
    {
        public Canciones[] cancion  { get; set; }
        public Usuario usuario;
        public Usuario[] usuarioDisponibles;
        public int cantidadTotalSong
        {
            get; set;
        }
       // public Usuario usuario { get; set; }

        public AddDatoMensaje()
        {

        }

    }
}
