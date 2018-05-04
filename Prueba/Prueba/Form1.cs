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
            /*if (CajaBsuquedaArchivos.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {


            }*/



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
