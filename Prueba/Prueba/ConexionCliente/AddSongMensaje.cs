﻿using Prueba.TCPCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.ConexionCliente
{
    public class AddSongMensaje : Mensajes
    {
        public Canciones cancion { get; set; }
       // public Usuario usuario { get; set; }

        public AddSongMensaje()
        {

        }

    }
}
