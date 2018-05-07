using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Dynamic;
using System.Xml.Linq;
using System.IO;
using System.IO;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Prueba.ConexionCliente;
using System.Xml.Serialization;
namespace Prueba.TCPCliente
{
    class SocketCliente
    {

        public SocketCliente()
        {

            //http://www.srikanthtechnologies.com/blog/java/java_cs_xml.aspx
           byte[] byteCancion = System.Text.Encoding.UTF8.GetBytes("holiwi");
            // Canciones cancion = new Canciones("Mana","albumcito","la Song","Metalero","HOLHAOHLAHOAHLAHOAHL", byteCancion[0]);
            Canciones cancion = new Canciones();
            cancion.nombreCancion = "Cancion de la hoguera";
            cancion.artista = "Bob Esponja";

            AddSongMensaje mensaje = new AddSongMensaje();
            mensaje.OpCod = "01";
            mensaje.cancion = cancion;
            mensaje.cancion.PRUEBAA = "212";

            //de object a xml


               string ObjectXML = ObjectToXml(mensaje);

            //de xml a object
            //   Canciones XMLObject = XMLtoObject<Canciones>(ObjectXML);
            ObjectXML=ObjectXML.Replace("\n", "").Replace("\r", "");
              Console.WriteLine(ObjectXML.ToString());
           // Console.WriteLine(XMLObject.nombreCancion);
           

            //IMPORTANTE
            
            TcpClient tcpClient = new TcpClient("localhost", 5000);
             NetworkStream networkStream = tcpClient.GetStream();
             byte[] datoByte;

             Console.WriteLine();
            string datoEnviar = ObjectXML;
              datoByte = Encoding.UTF8.GetBytes(datoEnviar+"\n");
            //Envia al servidor
             networkStream.Write(datoByte, 0, datoEnviar.Length + 1);
           
            
            //Importante*
            
            
             //Leer del servidor
             datoByte = new byte[312];
             networkStream.Read(datoByte, 0, 312);
             //El dato que se va a obtener
             String datorecibido = Encoding.UTF8.GetString(datoByte);
             //Quita los bytes sobrantes
             datorecibido = datorecibido.Substring(0, datorecibido.IndexOf(char.ConvertFromUtf32(0)));
             Console.WriteLine(datorecibido);


             


        }


        private String ObjectToXml<T>(T objetoCambio)
        {
            try
            {
                var stringwriter = new System.IO.StringWriter();
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stringwriter, objetoCambio);
                return stringwriter.ToString();
            }
            catch
            {
                throw;
            }
        }

        private T XMLtoObject<T>(string xmlCambio)
        {
            try
            {
                var stringReader = new System.IO.StringReader(xmlCambio);
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stringReader);
            }
            catch
            {
                throw;
            }
        }



    }
}
