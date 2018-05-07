using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace Prueba.TCPCliente
{
    class XMLGenerador
    {
        public String XMLDatos;

        public XMLGenerador(int tipo, String nombre, String artista, String album, String letra, String genero, String bytesCancion)
        {
            XMLDatos = CancionXML(nombre, artista, album, letra, genero, bytesCancion);

        }

        private String CancionXML(String nombre, String artista, String album, String letra, String genero, String bytesCancion)
        {
            XDocument doc = new XDocument(new XElement("body",
    
                new XElement("Nombre", nombre),
                new XElement("Artista", artista),
                new XElement("Album", album),
                new XElement("Letra", letra),
                new XElement("bytesCancion", bytesCancion)
                ));

            return doc.ToString().Replace("\n","");
        }
    }
}
