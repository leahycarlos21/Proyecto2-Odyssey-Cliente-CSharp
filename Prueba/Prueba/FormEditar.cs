using Prueba.ConexionCliente;
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
    public partial class FormEditar : Form
    {
        public Canciones cancionEditar { set; get; }
        private Canciones[] listaEdit = new Canciones[2];
        public FormEditar(Canciones cancionEntrante)
        {
            InitializeComponent();
            /** Se insertan los datos de la canción a editar en los textbox del formEditar*/
            nombretxt.Text = cancionEntrante.nombreCancion;
            artistatxt.Text = cancionEntrante.artista;
            albumtxt.Text = cancionEntrante.album;
            generotxt.Text = cancionEntrante.genero;

            cancionEditar = cancionEntrante;
            listaEdit[0]=cancionEntrante;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormEditar_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            letraCBox.DropDownStyle = ComboBoxStyle.DropDownList;
            cancionEditar.nombreCancion=nombretxt.Text;
            cancionEditar.artista = artistatxt.Text;
            cancionEditar.album= albumtxt.Text;
            cancionEditar.genero = generotxt.Text;
            cancionEditar.puntaje = Int32.Parse(letraCBox.Text) ;

            listaEdit[1] = cancionEditar;
            AddDatoMensaje mensajeCancion = new AddDatoMensaje();
            mensajeCancion.cancion = listaEdit;
            mensajeCancion.OpCod = "06";
            new SocketCliente(mensajeCancion);
            this.Close();


        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
