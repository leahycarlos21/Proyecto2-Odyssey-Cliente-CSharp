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
    public partial class addAmigos : Form
    {
        public Usuario usuarioAdded=null;
        Usuario[] listaUser;
        public Usuario usuariologin;
        public ListBox listBoxis;

        public addAmigos(Usuario[] listaUser,Usuario user, ListBox listBox)
        {
            listBoxis = listBox;
            usuariologin = user;
            this.listaUser = listaUser;
            InitializeComponent();
            addList.Items.Clear();

            for (int i = 0; i < listaUser.Length; i++)
            {
                addList.Items.Add(listaUser[i].nickName);
               
            }
        }

        private void addAmigos_Load(object sender, EventArgs e)
        {

        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            String amigoSelect = addList.SelectedItem.ToString();
            usuarioAdded = findAmigos(amigoSelect);
            listBoxis.Items.Add(usuarioAdded.nickName);




        }
        public Usuario findAmigos(String nickname)
        {
           for(int i = 0; i < listaUser.Length; i++)
            {
                if (listaUser[i].nickName.Equals(nickname))
                {
                    usuarioAdded = listaUser[i];
                    return listaUser[i];
                }
            }
            return null;
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
