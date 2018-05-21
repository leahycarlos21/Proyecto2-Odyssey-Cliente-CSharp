using Prueba.ConexionCliente;
using Prueba.TCPCliente;
using Prueba.User;
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
    public partial class Form2 : Form { 
        public String id { get; set; }
        public String password { get; set; }

    
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario();
            user.id = id;
            user.password = password;
            Console.WriteLine("se creo el usuario");
            Console.WriteLine(user.id);
            AddDatoMensaje mensajeUsuario = new AddDatoMensaje();
            mensajeUsuario.usuario = user;
            mensajeUsuario.OpCod = "06";
            Console.WriteLine("Va a entrar usuario");
            new SocketCliente(mensajeUsuario);
            this.Hide();
            Form1 Main = new Form1();
            Main.Show();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 ventana_registrar = new Form3();
            ventana_registrar.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            id = textBox1.Text;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            password = textBox2.Text;

        }
    }
}
