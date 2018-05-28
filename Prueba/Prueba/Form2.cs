using Prueba.ConexionCliente;
using Prueba.TCPCliente;
using Prueba.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba
{
    public partial class Form2 : Form { 
        public String nickName { get; set; }
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
            user.nickName = nickName;
            user.password = password;
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
            nickName = textBox1.Text;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            password = EncryptPasswords(textBox2.Text);

        }
        // Metodo encargado de encryptar la contrasena utilizando Hash Md5
        public String EncryptPasswords(String text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder str = new StringBuilder();
            for (int i = 1; i < result.Length; i++)
            {
                str.Append(result[i].ToString("x2"));


            }
            return str.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }

}
