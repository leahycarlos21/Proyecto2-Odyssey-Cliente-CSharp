﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

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
            TcpClient client = new TcpClient("localhost", 5000);

            // Console.Write("Enter name : ");

            //String name = Console.ReadLine();
            String name = "Larry";

            // send name to server
            byte[] buf;
            // append newline as server expects a line to be read
            buf = Encoding.UTF8.GetBytes(name + "\n");

            NetworkStream stream = client.GetStream();
            stream.Write(buf, 0, name.Length + 1);

            // read xml from server

            buf = new byte[100];
            stream.Read(buf, 0, 100);
            string xml = Encoding.UTF8.GetString(buf);
            // take only upto first null char
            xml = xml.Substring(0, xml.IndexOf(char.ConvertFromUtf32(0)));

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            if (doc.DocumentElement.Name == "error")
                Console.WriteLine("Name not found!");
            else
            {
                Console.WriteLine("Mobile : {0}", doc.SelectSingleNode("//mobile").InnerText);
                Console.WriteLine("Email  : {0}", doc.SelectSingleNode("//email").InnerText);
            }
        
    
    Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
