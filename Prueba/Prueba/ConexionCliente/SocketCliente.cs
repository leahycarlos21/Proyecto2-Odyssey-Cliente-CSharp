﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Dynamic;
using System.Xml.Linq;
using System.IO;

using System.Net;
using System.Net.Sockets;
using Prueba.ConexionCliente;
using System.Xml.Serialization;
using System.Xml;
using System.Windows.Forms;
using System.Threading;
using Prueba.User;

namespace Prueba.TCPCliente
{
    class SocketCliente
    {
        public Canciones[] ListaRecibida { set; get; }
        public Usuario[] usuariosRecibido { set; get; }
        public  int cantidadTotal { set; get; }

        public SocketCliente(AddDatoMensaje mensajeEntrante)
        {

            
            /**
             * El codigo de operacion se asigan al momento de crear el AddDatoMensaje en el metodo seleccionado, aqui solamente invoca la funcion usarSocket
             */
            //Enviar el mensaje tipo AddDatoMensaje y listo.
            //new ThreadExceptionDialog (new )
            if (mensajeEntrante.OpCod.Equals("01"))
            {

                
                                new Thread(() =>
                                {
                                    Thread.CurrentThread.IsBackground = true;
                                    /* run your code here */
                                    usarSocket(mensajeEntrante);

                                }).Start();
                
            }
            else
            {
                usarSocket(mensajeEntrante);
            }


        }

        public Canciones[] listaRecibida ()
        {
            return ListaRecibida;
        }
        public Canciones[] SocketClienteSong (AddDatoMensaje mensajeEntrante)
        {
            usarSocket(mensajeEntrante);
            return new Canciones[2];
        }

        private void usarSocket(AddDatoMensaje mensaje)
        {
            Console.WriteLine("entro a usarSockets");

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
            //  networkStream.Close();



            /**AQUI SE DEBE IMPLEMENTAR LO QUE SE VE HACER CON LO QUE HIZO EL SERVER*/
            //Leer del servidor

            StreamReader data_in = new StreamReader(tcpClient.GetStream());

            //El resultado recibido se asigna al datorecibido
            String datorecibido = data_in.ReadToEnd();
            tcpClient.Close();
            networkStream.Close();
            data_in.Close();

            if (mensaje.OpCod.Equals("01"))
            {
                MessageBox.Show(datorecibido);
            }
            else if (mensaje.OpCod.Equals("03"))
            {
                Console.WriteLine("entro");
                if (!mensaje.cantidadTotalSong.Equals(0))
                {
                    Canciones[] datoServer = XMLtoObject<Canciones[]>(datorecibido);
                    ListaRecibida = datoServer;
                    cantidadTotal = datoServer.Length;
                }

            }
            //Para solicitar los bytes y reproducir
            else if (mensaje.OpCod.Equals("04"))
            {
               
                Console.WriteLine("CancionRecibida");
                Canciones[] datoServer = XMLtoObject<Canciones[]>(datorecibido);
                ListaRecibida = datoServer;
                cantidadTotal = datoServer.Length;

            }
            else if (mensaje.OpCod.Equals("022"))
            {
                if (datorecibido.Equals("1"))
                {
                    Console.WriteLine("Usuario correcto");
                    Form2 form2 = new Form2();
                    form2.Close();
                    cantidadTotal = 100;

                }
                else
                {
                    MessageBox.Show("No existe, bateador");

                }
            }
            else if (mensaje.OpCod.Equals("9.1"))
            {
                Canciones[] datoServer = XMLtoObject<Canciones[]>(datorecibido);
                ListaRecibida = datoServer;
            }
            else if (mensaje.OpCod.Equals("9.2"))
            {
                Canciones[] datoServer = XMLtoObject<Canciones[]>(datorecibido);
                ListaRecibida = datoServer;
            }
            else if (mensaje.OpCod.Equals("9.3"))
            {
                Canciones[] datoServer = XMLtoObject<Canciones[]>(datorecibido);
                ListaRecibida = datoServer;
            }
            else if (mensaje.OpCod.Equals("10"))
            {
                Usuario[] datoServer = XMLtoObjectUser<Usuario[]>(datorecibido);
                usuariosRecibido = datoServer;
            }
            else if (mensaje.OpCod.Equals("10.1"))
            {
                Usuario[] datoServer = XMLtoObjectUser<Usuario[]>(datorecibido);
                usuariosRecibido = datoServer;
            }
            networkStream.Close();

            tcpClient.Close();


        }
        private AddDatoMensaje mensajeCancion(String codigoOp, Canciones[] cancion)
        {
            AddDatoMensaje mensaje = new AddDatoMensaje();
            mensaje.OpCod = codigoOp;
            mensaje.cancion = cancion;
            return mensaje;
        }


        private String ObjectToXml<T>(T objetoCambio)
        {
            if (objetoCambio == null)
            {
                return null;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(T));

            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Encoding = new UnicodeEncoding(false, false),
                Indent = false,
                OmitXmlDeclaration = false
            };

            using (StringWriter textWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    serializer.Serialize(xmlWriter, objetoCambio);
                }
                return textWriter.ToString();
            }
        }

        static byte[] RecibirDatos(NetworkStream netstr)
        {
            try
            {
                // Buffer to store the response bytes.
                byte[] recv = new Byte[99999999];

                // Read the first batch of the TcpServer response bytes.
                int bytes = netstr.Read(recv, 0, recv.Length); //(**This receives the data using the byte method**)

                byte[] a = new byte[bytes];

                for (int i = 0; i < bytes; i++)
                {
                    a[i] = recv[i];
                }

                return a;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!\n" + ex.Message + "\n" + ex.StackTrace);

                return null;
            }

        }


        /* private T XMLtoObject<T>(string xmlCambio)
         {
             try
             {
                 var stringReader = new System.IO.StringReader(xmlCambio);
                 var serializer = new XmlSerializer(typeof(T), new XmlRootAttribute("Canciones"));
                 return (T)serializer.Deserialize(stringReader);
             }
             catch(Exception ex)
             {
                 Console.WriteLine("----------------"+ex.GetBaseException());
                 throw;
             }
         }*/
        private T XMLtoObject<T>(string xmlCambio)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(T), new XmlRootAttribute("Canciones"));

                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(xmlCambio));

                return (T)xs.Deserialize(ms);
            }
            catch (Exception ex)
            {
                Console.WriteLine("----------------" + ex.GetBaseException());
                throw;
            }
        }
        private T XMLtoObjectUser<T>(string xmlCambio)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(T), new XmlRootAttribute("Usuario"));

                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(xmlCambio));

                return (T)xs.Deserialize(ms);
            }
            catch (Exception ex)
            {
                Console.WriteLine("----------------" + ex.GetBaseException());
                throw;
            }
        }




    }
}