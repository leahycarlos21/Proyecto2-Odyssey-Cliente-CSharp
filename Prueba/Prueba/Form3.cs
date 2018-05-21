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
using System.Security.Cryptography;
using Prueba.ConexionCliente;
using Prueba.TCPCliente;

namespace Prueba
{
    public partial class Form3 : Form
    {
        public String id { get; set; }
        public String password { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String edad { get; set; }

        public Form3()
        {
            InitializeComponent();

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            nombre = textBox4.Text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Se crea el usuraio y se le asignan cada valor escrito en los TextBox del Form
            Usuario user = new Usuario(id, password, nombre, apellido, edad);
            Console.WriteLine("se creo el usuario");
            this.Hide();
            Form1 Main = new Form1();
            Main.Show();
            Console.WriteLine(user.nombre);
            Console.WriteLine(user.apellido);
            Console.WriteLine(user.edad);
            Console.WriteLine(user.id);
            Console.WriteLine(user.password);
            AddDatoMensaje mensajeUsuario = new AddDatoMensaje();
            mensajeUsuario.usuario = user;
            mensajeUsuario.OpCod = "02";
            Console.WriteLine("Va a entrar usuario");
            new SocketCliente(mensajeUsuario);

            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            apellido = textBox3.Text;


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            edad = textBox2.Text;


        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            id = textBox1.Text;

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            password = EncryptPasswords(textBox5.Text);

        }
        // Metodo encargado de encryptar la contrasena utilizando Hash Md5
        public String EncryptPasswords(String text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder str = new StringBuilder();
            for (int i = 1 ; i < result.Length; i++)
            {
                str.Append(result[i].ToString("x2"));


            }
            return str.ToString();
        }
    }
}
