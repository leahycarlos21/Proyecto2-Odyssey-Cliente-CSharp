﻿using System;
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

        public SocketCliente(AddDatoMensaje mensajeEntrante)
        {

            //http://www.srikanthtechnologies.com/blog/java/java_cs_xml.aspx
            /**
             * El codigo de operacion se asigan al momento de crear el AddDatoMensaje en el metodo seleccionado, aqui solamente invoca la funcion usarSocket
             */
                //Enviar el mensaje tipo AddDatoMensaje y listo.
                usarSocket(mensajeEntrante);

            
        
             


        }

        private void usarSocket(AddDatoMensaje mensaje)
        {
            string ObjectXML = ObjectToXml(mensaje);

            //de xml a object
            //   Canciones XMLObject = XMLtoObject<Canciones>(ObjectXML);
            ObjectXML = ObjectXML.Replace("\n", "").Replace("\r", "");
            Console.WriteLine(ObjectXML.ToString());
            // Console.WriteLine(XMLObject.nombreCancion);


            //IMPORTANTE

            TcpClient tcpClient = new TcpClient("localhost", 5000);
            NetworkStream networkStream = tcpClient.GetStream();
            byte[] datoByte;

            Console.WriteLine();
            string datoEnviar = ObjectXML;
            datoByte = Encoding.UTF8.GetBytes(datoEnviar + "\n");
            //Envia al servidor
            networkStream.Write(datoByte, 0, datoEnviar.Length + 1);


   
            /**AQUI SE DEBE IMPLEMENTAR LO QUE SE VE HACER CON LO QUE HIZO EL SERVER*/
            //Leer del servidor
            datoByte = new byte[312];
            networkStream.Read(datoByte, 0, 312);
            //El dato que se va a obtener
            String datorecibido = Encoding.UTF8.GetString(datoByte);
            //Quita los bytes sobrantes
            datorecibido = datorecibido.Substring(0, datorecibido.IndexOf(char.ConvertFromUtf32(0)));
            Console.WriteLine(datorecibido);

        }
        private AddDatoMensaje mensajeCancion(String codigoOp,Canciones cancion)
        {
            AddDatoMensaje mensaje = new AddDatoMensaje();
            mensaje.OpCod = codigoOp;
            mensaje.cancion = cancion;
          //  mensaje.cancion.PRUEBAA = "212";
            return mensaje;
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