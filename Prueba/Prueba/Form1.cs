using NAudio.Wave;
using Prueba.ConexionCliente;
using Prueba.TCPCliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba
{
    public partial class Form1 : Form
    {
        private IWavePlayer wavePlayer;
        private Mp3FileReader reader;
        private Canciones[] CancionesDGV;
        private int pageNumber = 1;
        public String[] cancionSelect = new String[2];
        public Canciones[] selectDVG = new Canciones[1];
        private int lazyLoadingPos = 1;

        SocketCliente socketPrincipal;
        
        
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 500;
            timer1.Start();
            dGV.Columns.Add("Artista", "Artista");
            dGV.Columns.Add("Album", "Album");
            dGV.Columns.Add("Canción", "Canción");
            dGV.Columns.Add("Género", "Género");
            dGV.Columns.Add("Letra", "Letra");
            loadDataGridView();
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
                    //Array que va a tener las canciones insertadas
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
                        cancionEntrante.letra = tagFile.Tag.Comment;
                        byte[] bytesCancionSelect = ReadAllBytes(rutasMP3[cantidadMp3].ToString());
                        Console.WriteLine("largo de bytes es" + bytesCancionSelect.Length);
                        cancionEntrante.bytesSong = bytesCancionSelect;
                        CancionesTotal[cantidadMp3] = cancionEntrante;


                        //CancionesTotal[1] = cancionEntrante;

                        //  CancionesTotal[1] = cancionEntrante;


                        ///https://stackoverflow.com/questions/1003275/how-to-convert-utf-8-byte-to-string
                        cantidadMp3++;
                    }

                  //  cargarArchivo(CancionesTotal[0].bytesSong);


                  //  CancionesDGV = CancionesTotal;
                    //loadDataGridView();
                    AddDatoMensaje mensajeCancion = new AddDatoMensaje();
                    mensajeCancion.cancion = CancionesTotal;
                    mensajeCancion.OpCod = "01";


                   socketPrincipal= new SocketCliente(mensajeCancion);
                    loadDataGridView();


                }




            }
            catch (Exception error)
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


        private void cargarArchivo(byte[] cancion)
        {
            reader?.Dispose();
            reader = null;

            byte[] mp3Bytes = cancion;
            var mp3Stream = new MemoryStream(mp3Bytes);

            reader = new Mp3FileReader(mp3Stream);
            //  DisplayPosition();


        }

        private void loadDataGridView() 
        {
            if (lazyLoadingPos.Equals(1))
            {
                anteriorbutton.Enabled = false;
               // buttonStop.Enabled = isPlaying;
            }
            else if (!lazyLoadingPos.Equals(1))
            {
                anteriorbutton.Enabled = true;

            }
            dGV.Rows.Clear();
            AddDatoMensaje mensajeCancion = new AddDatoMensaje();
            mensajeCancion.OpCod = "03";
            mensajeCancion.cantidadTotalSong = lazyLoadingPos;


            SocketCliente socketis = new SocketCliente(mensajeCancion);
            CancionesDGV = socketis.listaRecibida();
            double rangoNumeros = socketis.cantidadTotal/3;
            Console.WriteLine(rangoNumeros);

            rangoNumeros = Math.Round(rangoNumeros);

            pageLabel.Text = string.Format("Pág. {0}/{1}", pageNumber, rangoNumeros);
            int num = 0;
           
            dGV.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGV.Columns[4].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

           for (int i = 0; i < CancionesDGV.Length; i++)
            {
                dGV.Rows.Add(new object[] { CancionesDGV[i].artista, CancionesDGV[i].album,
                CancionesDGV[i].nombreCancion,CancionesDGV[i].genero,CancionesDGV[i].letra});
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }






        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelPosition_Click(object sender, EventArgs e)
        {

        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (wavePlayer == null)
            {
                wavePlayer = new WaveOutEvent();
            }
            wavePlayer.Init(reader);
            wavePlayer.Play();
            ControlesHabilitados(true);
            //    https://www.youtube.com/watch?v=L1wpQ_fKjVw
        }
        private void ControlesHabilitados(bool isPlaying)
        {
            buttonPlay.Enabled = !isPlaying;
            buttonStop.Enabled = isPlaying;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            wavePlayer?.Stop();
            ControlesHabilitados(false);
        }

        private void trackBarPlaybackPosition_Scroll(object sender, EventArgs e)
        {
            if (reader != null)
            {
                reader.CurrentTime = TimeSpan.FromSeconds(trackBarPlaybackPosition.Value);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (reader != null)
                {

                    trackBarPlaybackPosition.Value = (int)reader.CurrentTime.TotalSeconds;
                    DisplayPosition();
                }
            }catch(Exception )
            {
                
                wavePlayer?.Stop();
                ControlesHabilitados(false);
                DisplayPosition();
            }
           
        }

        //Resetea la posicion del tiempo de reproduccion
        private void DisplayPosition()
        {
            timeLabel.Text = reader.CurrentTime.ToString("mm\\:ss");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CllContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cancionSelect[0] = dGV.Rows[e.RowIndex].Cells["Artista"].Value.ToString();
            cancionSelect[1] = dGV.Rows[e.RowIndex].Cells["Canción"].Value.ToString();

            Console.WriteLine(cancionSelect[0]+cancionSelect[1]);

            for (int i = 0; i < CancionesDGV.Length; i++)
            {
                if (CancionesDGV[i].artista.Equals(cancionSelect[0])
                    && CancionesDGV[i].nombreCancion.Equals(cancionSelect[1]))
                {
                    AddDatoMensaje mensajeCancion = new AddDatoMensaje();
                    mensajeCancion.cancion = new Canciones[1];
                    mensajeCancion.cancion[0] = CancionesDGV[i];
                    mensajeCancion.OpCod = "04";

                    socketPrincipal=new SocketCliente(mensajeCancion);
                    MessageBox.Show("Canción disponible");
                    selectDVG[0] = CancionesDGV[i];
                    cargarArchivo(socketPrincipal.ListaRecibida[0].bytesSong);
                    break;
                }
            }
        }

        private void eliminarbtn_Click(object sender, EventArgs e)
        {
            AddDatoMensaje mensajeCancion = new AddDatoMensaje();
            mensajeCancion.cancion = selectDVG;
            mensajeCancion.OpCod = "05";
            mensajeCancion.cancion[0].bytesSong = null;
            socketPrincipal=new SocketCliente(mensajeCancion);
            loadDataGridView();
        }

        private void siguientebutton_Click(object sender, EventArgs e)
        {
            lazyLoadingPos += 3;
            loadDataGridView();
        }

        private void anteriorbutton_Click(object sender, EventArgs e)
        {
            lazyLoadingPos -= 3;
            loadDataGridView();
        }
    }


}
