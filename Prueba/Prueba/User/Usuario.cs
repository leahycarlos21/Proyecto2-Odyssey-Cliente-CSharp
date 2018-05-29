using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Prueba.User
{
    [Serializable()]
    [XmlRoot("Usuario")]
    public class Usuario
    {
        [System.Xml.Serialization.XmlElement("nickName")]
        public String nickName { get; set; }
        [System.Xml.Serialization.XmlElement("password")]
        public String password { get; set; }
        [System.Xml.Serialization.XmlElement("nombre")]

        public String nombre { get; set; }
        [System.Xml.Serialization.XmlElement("apellido")]

        public String apellido { get; set; }
        [System.Xml.Serialization.XmlElement("edad")]

        public String edad { get; set; }
        [System.Xml.Serialization.XmlElement("hojaIzquierda")]

        public Usuario hojaIzquierda { get; set; }
        [System.Xml.Serialization.XmlElement("hojaDerecha")]

        public Usuario hojaDerecha { get; set; }
        [System.Xml.Serialization.XmlElement("amigos")]

        public Usuario[] amigos { get; set; }
        [System.Xml.Serialization.XmlElement("mensajes")]

        public String[] mensajes { get; set; }

        //Constructores pa
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
