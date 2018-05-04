using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Xml.Linq;
using System.IO;

namespace Odyssey_Cliente
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // connect to server
            //TcpClient client = new TcpClient("localhost", 5000);


            //String name = Console.ReadLine();
            String name = "Larry";
            Int32 age = 30;
            String city = "Copenhagen";
            String country = "Denmark";
            //https://stackoverflow.com/questions/11492705/how-to-create-xml-document-using-xmldocument
            XElement xmlCliente = new XElement("DATA",
                new XAttribute("ID", 1),
                new XElement("Field",
                    new XAttribute("Name", "Name"),
                    name),
                new XElement("Field",
                    new XAttribute("Name", "Age"),
                    age),
                new XElement("Field",
                    new XAttribute("Name", "City"),
                    city),
                new XElement("Field",
                    new XAttribute("Name", "Country"),
                    country)
            );

            Console.WriteLine(xmlCliente);
            using (var clienteSocket = new TcpClient())
            {
                clienteSocket.Connect("localhost", 5000);
                using (var ns = clienteSocket.GetStream())
                using (var writer = new StreamWriter(ns))
                {
                    writer.Write(xmlCliente);
                  //  writer.Write("\r\n\r\n");
                    writer.Flush();
                }
                clienteSocket.Close();
            }
        
                /*  // send name to server
                  byte[] buf;
                  // append newline as server expects a line to be read
                  buf = Encoding.UTF8.GetBytes(xmlCliente + "\n");

                  NetworkStream stream = client.GetStream();
                  stream.Write(buf, 0, name.Length + 1);

                  // read xml from server

                  buf = new byte[1000];
                  stream.Read(buf, 0, 100);
                  string xml = Encoding.UTF8.GetString(buf);
                  // take only upto first null char
                  xml = xml.Substring(0, xml.IndexOf(char.ConvertFromUtf32(0)));

                 /* XmlDocument doc = new XmlDocument();
                  doc.LoadXml(xml);

                  if (doc.DocumentElement.Name == "error")
                      Console.WriteLine("Name not found!");
                  else
                  {
                      Console.WriteLine("Mobile : {0}", doc.SelectSingleNode("//mobile").InnerText);
                      Console.WriteLine("Email  : {0}", doc.SelectSingleNode("//email").InnerText);
                  }*/


                Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
