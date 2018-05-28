using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.User
{
    public class Usuario
    {
        public String nickName { get; set; }
        public String password { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String edad { get; set; }
        public Usuario hojaIzquierda { get; set; }
        public Usuario hojaDerecha { get; set; }
        //public [] mensajes {get; set;}


        public Usuario(String nickName, String password, String nombre, String apellido, String edad)
        {
            this.nickName = nickName;
            this.password = password;
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;

        }

        public Usuario()
        {

        }

    }

}
