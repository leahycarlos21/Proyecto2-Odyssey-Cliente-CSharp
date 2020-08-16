namespace Prueba
{
    partial class FormEditar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nombretxt = new System.Windows.Forms.TextBox();
            this.artistatxt = new System.Windows.Forms.TextBox();
            this.albumtxt = new System.Windows.Forms.TextBox();
            this.generotxt = new System.Windows.Forms.TextBox();
            this.confirmbtn = new System.Windows.Forms.Button();
            this.cancelbtn = new System.Windows.Forms.Button();
            this.letraCBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Artista/Grupo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Album:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Género:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Puntaje:";
            // 
            // nombretxt
            // 
            this.nombretxt.Location = new System.Drawing.Point(128, 44);
            this.nombretxt.Name = "nombretxt";
            this.nombretxt.Size = new System.Drawing.Size(179, 20);
            this.nombretxt.TabIndex = 5;
            // 
            // artistatxt
            // 
            this.artistatxt.Location = new System.Drawing.Point(128, 75);
            this.artistatxt.Name = "artistatxt";
            this.artistatxt.Size = new System.Drawing.Size(179, 20);
            this.artistatxt.TabIndex = 6;
            // 
            // albumtxt
            // 
            this.albumtxt.Location = new System.Drawing.Point(128, 108);
            this.albumtxt.Name = "albumtxt";
            this.albumtxt.Size = new System.Drawing.Size(179, 20);
            this.albumtxt.TabIndex = 7;
            // 
            // generotxt
            // 
            this.generotxt.Location = new System.Drawing.Point(128, 134);
            this.generotxt.Name = "generotxt";
            this.generotxt.Size = new System.Drawing.Size(179, 20);
            this.generotxt.TabIndex = 8;
            // 
            // confirmbtn
            // 
            this.confirmbtn.Location = new System.Drawing.Point(101, 337);
            this.confirmbtn.Name = "confirmbtn";
            this.confirmbtn.Size = new System.Drawing.Size(75, 23);
            this.confirmbtn.TabIndex = 10;
            this.confirmbtn.Text = "Confirmar Cambios";
            this.confirmbtn.UseVisualStyleBackColor = true;
            this.confirmbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // cancelbtn
            // 
            this.cancelbtn.Location = new System.Drawing.Point(212, 339);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(75, 23);
            this.cancelbtn.TabIndex = 11;
            this.cancelbtn.Text = "Cancelar";
            this.cancelbtn.UseVisualStyleBackColor = true;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // letraCBox
            // 
            this.letraCBox.FormattingEnabled = true;
            this.letraCBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.letraCBox.Location = new System.Drawing.Point(128, 160);
            this.letraCBox.Name = "letraCBox";
            this.letraCBox.Size = new System.Drawing.Size(121, 21);
            this.letraCBox.TabIndex = 12;
            // 
            // FormEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 372);
            this.Controls.Add(this.letraCBox);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.confirmbtn);
            this.Controls.Add(this.generotxt);
            this.Controls.Add(this.albumtxt);
            this.Controls.Add(this.artistatxt);
            this.Controls.Add(this.nombretxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormEditar";
            this.Text = "FormEditar";
            this.Load += new System.EventHandler(this.FormEditar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox nombretxt;
        private System.Windows.Forms.TextBox artistatxt;
        private System.Windows.Forms.TextBox albumtxt;
        private System.Windows.Forms.TextBox generotxt;
        private System.Windows.Forms.Button confirmbtn;
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.ComboBox letraCBox;
    }
}