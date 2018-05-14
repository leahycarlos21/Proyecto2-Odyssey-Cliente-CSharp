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


                    while (cantidadMp3 < largoCancionesMp3)
                    {

                        Canciones cancionEntrante = new Canciones();
                        TagLib.File tagFile = TagLib.File.Create(rutasMP3[cantidadMp3].ToString());
                        //  Console.WriteLine("------------"+ tagFile.Tag.FirstArtist.ToString());
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
                        cancionEntrante.artista = tagFile.Tag.FirstArtist.ToString();
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
                        cancionEntrante.album = tagFile.Tag.Album;
                        cancionEntrante.nombreCancion = tagFile.Tag.Title;
                        cancionEntrante.genero = tagFile.Tag.FirstGenre;
                        CancionesTotal[cantidadMp3] = cancionEntrante;
                        //var bytes = File.ReadAllBytes(fileName);
                        byte[] bytesCancionSelect = ReadAllBytes(rutasMP3[cantidadMp3].ToString());
                        Console.WriteLine("largo de bytes es"+bytesCancionSelect.Length);
                        cancionEntrante.bytesSong = bytesCancionSelect;
                        
                       //CancionesTotal[1] = cancionEntrante;

                        //  CancionesTotal[1] = cancionEntrante;


                        ///https://stackoverflow.com/questions/1003275/how-to-convert-utf-8-byte-to-string
                        cantidadMp3++;
                    }
                    
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
