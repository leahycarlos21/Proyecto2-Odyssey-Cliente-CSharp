namespace Prueba
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.Agregar = new System.Windows.Forms.PictureBox();
            this.Ordenar = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Buscar = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.trackBarPlaybackPosition = new System.Windows.Forms.TrackBar();
            this.timeLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dGV = new System.Windows.Forms.DataGridView();
            this.anteriorbutton = new System.Windows.Forms.Button();
            this.siguientebutton = new System.Windows.Forms.Button();
            this.pageLabel = new System.Windows.Forms.Label();
            this.eliminarbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Agregar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPlaybackPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Agregar Música";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Agregar
            // 
            this.Agregar.Image = global::Prueba.Properties.Resources.agregar;
            this.Agregar.InitialImage = global::Prueba.Properties.Resources.agregar;
            this.Agregar.Location = new System.Drawing.Point(99, 15);
            this.Agregar.Name = "Agregar";
            this.Agregar.Size = new System.Drawing.Size(34, 29);
            this.Agregar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Agregar.TabIndex = 4;
            this.Agregar.TabStop = false;
            this.Agregar.Click += new System.EventHandler(this.Agregar_Click);
            // 
            // Ordenar
            // 
            this.Ordenar.FormattingEnabled = true;
            this.Ordenar.Location = new System.Drawing.Point(463, 26);
            this.Ordenar.Name = "Ordenar";
            this.Ordenar.Size = new System.Drawing.Size(108, 21);
            this.Ordenar.TabIndex = 5;
            this.Ordenar.Text = "Ordenar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Buscar canción:";
            // 
            // Buscar
            // 
            this.Buscar.Location = new System.Drawing.Point(197, 25);
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(239, 20);
            this.Buscar.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(864, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 25);
            this.button1.TabIndex = 8;
            this.button1.Text = "Nombre de canción";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(864, 57);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(160, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Artista";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(864, 86);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(160, 22);
            this.button3.TabIndex = 10;
            this.button3.Text = "Álbum";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(864, 114);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(159, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "Letra de la canción";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1105, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Agregar Amigos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1105, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "AMIGOS";
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(18, 478);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(75, 23);
            this.buttonPlay.TabIndex = 14;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(20, 507);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(73, 23);
            this.buttonStop.TabIndex = 15;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // trackBarPlaybackPosition
            // 
            this.trackBarPlaybackPosition.Location = new System.Drawing.Point(116, 485);
            this.trackBarPlaybackPosition.Maximum = 100;
            this.trackBarPlaybackPosition.Name = "trackBarPlaybackPosition";
            this.trackBarPlaybackPosition.Size = new System.Drawing.Size(455, 45);
            this.trackBarPlaybackPosition.SmallChange = 5;
            this.trackBarPlaybackPosition.TabIndex = 16;
            this.trackBarPlaybackPosition.TickFrequency = 5;
            this.trackBarPlaybackPosition.Scroll += new System.EventHandler(this.trackBarPlaybackPosition_Scroll);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(577, 488);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(34, 13);
            this.timeLabel.TabIndex = 17;
            this.timeLabel.Text = "00:00";
            this.timeLabel.Click += new System.EventHandler(this.labelPosition_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dGV
            // 
            this.dGV.AllowUserToAddRows = false;
            this.dGV.AllowUserToDeleteRows = false;
            this.dGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dGV.Location = new System.Drawing.Point(12, 57);
            this.dGV.Name = "dGV";
            this.dGV.RowTemplate.Height = 85;
            this.dGV.RowTemplate.ReadOnly = true;
            this.dGV.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGV.Size = new System.Drawing.Size(772, 340);
            this.dGV.StandardTab = true;
            this.dGV.TabIndex = 18;
            this.dGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_CellContentClick);
            // 
            // anteriorbutton
            // 
            this.anteriorbutton.Location = new System.Drawing.Point(203, 438);
            this.anteriorbutton.Name = "anteriorbutton";
            this.anteriorbutton.Size = new System.Drawing.Size(75, 23);
            this.anteriorbutton.TabIndex = 19;
            this.anteriorbutton.Text = "<";
            this.anteriorbutton.UseVisualStyleBackColor = true;
            this.anteriorbutton.Click += new System.EventHandler(this.anteriorbutton_Click);
            // 
            // siguientebutton
            // 
            this.siguientebutton.Location = new System.Drawing.Point(392, 438);
            this.siguientebutton.Name = "siguientebutton";
            this.siguientebutton.Size = new System.Drawing.Size(75, 23);
            this.siguientebutton.TabIndex = 20;
            this.siguientebutton.Text = ">";
            this.siguientebutton.UseVisualStyleBackColor = true;
            this.siguientebutton.Click += new System.EventHandler(this.siguientebutton_Click);
            // 
            // pageLabel
            // 
            this.pageLabel.AutoSize = true;
            this.pageLabel.Location = new System.Drawing.Point(319, 448);
            this.pageLabel.Name = "pageLabel";
            this.pageLabel.Size = new System.Drawing.Size(0, 13);
            this.pageLabel.TabIndex = 21;
            // 
            // eliminarbtn
            // 
            this.eliminarbtn.Location = new System.Drawing.Point(633, 25);
            this.eliminarbtn.Name = "eliminarbtn";
            this.eliminarbtn.Size = new System.Drawing.Size(75, 23);
            this.eliminarbtn.TabIndex = 22;
            this.eliminarbtn.Text = "Eliminar";
            this.eliminarbtn.UseVisualStyleBackColor = true;
            this.eliminarbtn.Click += new System.EventHandler(this.eliminarbtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1278, 570);
            this.Controls.Add(this.eliminarbtn);
            this.Controls.Add(this.pageLabel);
            this.Controls.Add(this.siguientebutton);
            this.Controls.Add(this.anteriorbutton);
            this.Controls.Add(this.dGV);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.trackBarPlaybackPosition);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Buscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Ordenar);
            this.Controls.Add(this.Agregar);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Reproductor de música";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Agregar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPlaybackPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox Agregar;
        private System.Windows.Forms.ComboBox Ordenar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Buscar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.TrackBar trackBarPlaybackPosition;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dGV;
        private System.Windows.Forms.Button anteriorbutton;
        private System.Windows.Forms.Button siguientebutton;
        private System.Windows.Forms.Label pageLabel;
        private System.Windows.Forms.Button eliminarbtn;
    }
}

