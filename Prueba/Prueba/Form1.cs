using Prueba.TCPCliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

     

        private void Agregar_Click(object sender, EventArgs e)
        {
            OpenFileDialog CajaBsuquedaArchivos = new OpenFileDialog();
            CajaBsuquedaArchivos.Multiselect = true;
            if (CajaBsuquedaArchivos.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                String[] ArchivosMP3;
                String[] rutasMP3;
                ArchivosMP3 = CajaBsuquedaArchivos.SafeFileNames;
                rutasMP3 = CajaBsuquedaArchivos.FileNames;
                foreach (var rutaMp3 in rutasMP3)
                {
                    byte[] byteCancion = System.IO.File.ReadAllBytes(rutaMp3.ToString());
                    // Console.WriteLine(byteCancion[0].ToString());
                    int num = 0;
                  /*  while (byteCancion[num]!=null)
                    {

                        Console.WriteLine(byteCancion[num].ToString());
                        num++;
                    }   */

                }
                new SocketCliente();
           
           }



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
