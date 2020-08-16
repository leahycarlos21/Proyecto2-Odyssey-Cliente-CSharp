using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Prueba.TCPCliente

{
    [Serializable()]
    [XmlRoot("Canciones")]
    public class Canciones
    {
        [System.Xml.Serialization.XmlElement("artista")]
        public String artista { get; set; }
        [System.Xml.Serialization.XmlElement("album")]

        public String album { get; set; }
        [System.Xml.Serialization.XmlElement("nombreCancion")]

        public String nombreCancion { get; set; }
        [System.Xml.Serialization.XmlElement("genero")]

        public String genero { get; set; }
        [System.Xml.Serialization.XmlElement("letra")]
        public String letra { get; set; }
        [System.Xml.Serialization.XmlElement("ID")]

        public int ID { get; set; }

        [System.Xml.Serialization.XmlElement("bytesSong")]
        public byte[] bytesSong { get; set; }

        [System.Xml.Serialization.XmlElement("puntaje")]
        public int puntaje { get; set; }

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
