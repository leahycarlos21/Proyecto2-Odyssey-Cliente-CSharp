using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.TCPCliente
{
    public class Canciones
    {
        public String artista { get; set; }
        public String album { get; set; }
        public String nombreCancion { get; set; }
        public String genero { get; set; }
        public String letra { get; set; }
        //public String PRUEBAA { get; set; }

        public byte[] bytesSong { get; set; }

        public Canciones()
        {

        }
        public Canciones(String artista,String album, String nombreCancion, String genero, String letra, byte[] byteSong)
        {
            this.artista = artista;
            this.album = album;
            this.nombreCancion = nombreCancion;
            this.genero = genero;
            this.letra = letra;
            this.bytesSong = byteSong;
        }
  }
}
