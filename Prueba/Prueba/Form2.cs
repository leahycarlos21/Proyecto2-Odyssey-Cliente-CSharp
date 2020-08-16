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
    public partial class Form2 : Form
    {
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
            user.nickName = textBox1.Text;
            user.password = EncryptPasswords(textBox2.Text);
            Console.WriteLine(user.nickName);
            Console.WriteLine(user.password);

            AddDatoMensaje mensajeUsuario = new AddDatoMensaje();
            mensajeUsuario.usuario = user;
            mensajeUsuario.OpCod = "022";
            Console.WriteLine("Va a entrar usuario");
            SocketCliente socketin =new SocketCliente(mensajeUsuario);
            if (socketin.cantidadTotal == 100)
            {
                Form1 Main = new Form1(user);
                Main.Show();
            }
            else
            {

            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //Se crea una nueva ventana de registro crear un nuevo usuario.
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 ventana_registrar = new Form3();
            ventana_registrar.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        //Caja de texto en el cual se va a ingresar el nombre de usuario.
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            nickName = textBox1.Text;

        }
        //Caja de texto donde se insertara la contrasena, el programa la encrypa
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }

}
