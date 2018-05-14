using Prueba.ConexionCliente;
using Prueba.TCPCliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

            try
            {
                OpenFileDialog CajaBsuquedaArchivos = new OpenFileDialog();
                CajaBsuquedaArchivos.Multiselect = true;
                if (CajaBsuquedaArchivos.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //String[] ArchivosMP3;
                    String[] rutasMP3;
                    // ArchivosMP3 = CajaBsuquedaArchivos.SafeFileNames;
                    rutasMP3 = CajaBsuquedaArchivos.FileNames;
                    int cantidadMp3 = 0;
                    int largoCancionesMp3 = rutasMP3.Length;
                    /**Array que va a tener las canciones insertadas*/
                    Canciones[] CancionesTotal = new Canciones[largoCancionesMp3];

                    // Console.WriteLine(largoCancionesMp3);
                    //Canciones cancionEntrante = new Canciones();
                    /*TagLib.File tagFile = TagLib.File.Create(rutasMP3[cantidadMp3].ToString());
                    Console.WriteLine("------------" + tagFile.Tag.FirstArtist.ToString());
                    cancionEntrante.artista = tagFile.Tag.FirstArtist.ToString();
                    cancionEntrante.album = tagFile.Tag.Album.ToString();
                       cancionEntrante.nombreCancion = tagFile.Tag.Title;
                    cancionEntrante.genero = tagFile.Tag.FirstGenre;

                    byte[] bytesCancionSelect = System.IO.File.ReadAllBytes(rutasMP3[0].ToString());
                    cancionEntrante.bytesSong = bytesCancionSelect;
                    CancionesTotal[0] = cancionEntrante;*/

                    while (cantidadMp3 < largoCancionesMp3)
                    {

                        Canciones cancionEntrante = new Canciones();
                        TagLib.File tagFile = TagLib.File.Create(rutasMP3[cantidadMp3].ToString());
                        //  Console.WriteLine("------------"+ tagFile.Tag.FirstArtist.ToString());
                        cancionEntrante.artista = tagFile.Tag.FirstArtist.ToString();
                        cancionEntrante.album = tagFile.Tag.Album;
                        cancionEntrante.nombreCancion = tagFile.Tag.Title;
                        cancionEntrante.genero = tagFile.Tag.FirstGenre;
                        CancionesTotal[cantidadMp3] = cancionEntrante;
                        //var bytes = File.ReadAllBytes(fileName);
                        byte[] bytesCancionSelect = ReadAllBytes(rutasMP3[cantidadMp3].ToString());//File.ReadAllBytes(rutasMP3[cantidadMp3].ToString());// System.IO.File.ReadAllBytes(rutasMP3[cantidadMp3].ToString());
                        Console.WriteLine("largo de bytes es"+bytesCancionSelect.Length);
                        cancionEntrante.bytesSong = bytesCancionSelect;
                        
                       //CancionesTotal[1] = cancionEntrante;

                        //  CancionesTotal[1] = cancionEntrante;


                        ///https://stackoverflow.com/questions/1003275/how-to-convert-utf-8-byte-to-string
                        cantidadMp3++;
                    }


                    /* foreach (var rutaMp3 in rutasMP3)
                     {
                         Canciones cancionEntrante = new Canciones();
                         //Libreria para leer el metadata del mp3, y insertarlo ala cancionEntrante

                         TagLib.File tagFile = TagLib.File.Create(rutaMp3.ToString());
                         cancionEntrante.artista = tagFile.Tag.FirstArtist;

                         cancionEntrante.album = tagFile.Tag.Album;
                         cancionEntrante.nombreCancion = tagFile.Tag.Title;
                         cancionEntrante.genero = tagFile.Tag.FirstGenre;

                         //Lee los bytes de la cancion

                         byte[] bytesCancionSelect = System.IO.File.ReadAllBytes(rutaMp3.ToString());
                         cancionEntrante.bytesSong = bytesCancionSelect;
                         CancionesTotal[cantidadMp3] = cancionEntrante;
                         cantidadMp3++;
                     }*/
                    //  Console.WriteLine("Salio");
                    /* byte[] byteCancion = System.Text.Encoding.UTF8.GetBytes("holiwi");
                     // Canciones cancion = new Canciones("Mana","albumcito","la Song","Metalero","HOLHAOHLAHOAHLAHOAHL", byteCancion[0]);
                     Canciones cancionNueva = new Canciones();
                     cancionNueva.nombreCancion = "Cancion de la hoguera";
                     cancionNueva.artista = "Bob Esponja";
                    // Canciones[] CancionesTotal = new Canciones[1];
                     //CancionesTotal[0] = cancionNueva;*/
                    AddDatoMensaje mensajeCancion = new AddDatoMensaje();
                    mensajeCancion.cancion = CancionesTotal;
                    mensajeCancion.OpCod = "01";

                     new SocketCliente(mensajeCancion);

                }


            }catch(Exception error )
            {
                Console.WriteLine(error);
            }
        }
        public byte[] ReadAllBytes(string fileName)
        {
            byte[] buffer = null;
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
            }
            return buffer;
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
