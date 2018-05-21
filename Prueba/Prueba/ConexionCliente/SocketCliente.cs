using System;
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

namespace Prueba.TCPCliente
{
    class SocketCliente
    {
        public   Canciones[] ListaRecibida { set; get; }
        public  int cantidadTotal { set; get; }

        public SocketCliente(AddDatoMensaje mensajeEntrante)
        {

            //http://www.srikanthtechnologies.com/blog/java/java_cs_xml.aspx
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
            //  ReceiveAll(networkStream);


            // Do something with the resultStream, like resultStream.ToArray() ...

            StreamReader data_in = new StreamReader(tcpClient.GetStream());
            //  Console.WriteLine(data_in.ReadToEnd());
            //  data_in.ToString();
           
            String datorecibido = data_in.ReadToEnd();
            tcpClient.Close();
            networkStream.Close();
            data_in.Close();
            // networkStream.Read(datoByte, 0, 99999999);
            // 444448847

            //El dato que se va a obtener
            //    String datorecibido = Encoding.UTF8.GetString(bytecito);

            //Quita los bytes sobrantes
            //  datorecibido = datorecibido.Replace("\0", string.Empty);
            // datorecibido = datorecibido.Substring(0, datorecibido.IndexOf(char.ConvertFromUtf32(0)));
            //Console.WriteLine(datorecibido);
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
            else if (mensaje.OpCod.Equals("04")){
                Console.WriteLine("CancionRecibida");
                Canciones[] datoServer = XMLtoObject<Canciones[]>(datorecibido);
                ListaRecibida = datoServer;
                cantidadTotal = datoServer.Length;

            }
            networkStream.Close();

            tcpClient.Close();


        }
        private AddDatoMensaje mensajeCancion(String codigoOp, Canciones[] cancion)
        {
            AddDatoMensaje mensaje = new AddDatoMensaje();
            mensaje.OpCod = codigoOp;
            mensaje.cancion = cancion;
          //  mensaje.cancion.PRUEBAA = "212";
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
                Encoding = new UnicodeEncoding(false, false), // no BOM in a .NET string
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
      



    }
}
