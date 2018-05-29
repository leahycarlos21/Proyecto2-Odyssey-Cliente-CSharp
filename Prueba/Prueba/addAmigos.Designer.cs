namespace Prueba
{
    partial class addAmigos
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
            this.addList = new System.Windows.Forms.ListBox();
            this.cancelbtn = new System.Windows.Forms.Button();
            this.addbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addList
            // 
            this.addList.FormattingEnabled = true;
            this.addList.Location = new System.Drawing.Point(62, 42);
            this.addList.Name = "addList";
            this.addList.Size = new System.Drawing.Size(184, 212);
            this.addList.TabIndex = 0;
            // 
            // cancelbtn
            // 
            this.cancelbtn.Location = new System.Drawing.Point(195, 283);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(75, 23);
            this.cancelbtn.TabIndex = 1;
            this.cancelbtn.Text = "Cancelar";
            this.cancelbtn.UseVisualStyleBackColor = true;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // addbtn
            // 
            this.addbtn.Location = new System.Drawing.Point(50, 283);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(75, 23);
            this.addbtn.TabIndex = 2;
            this.addbtn.Text = "Añadir";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // addAmigos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 397);
            this.Controls.Add(this.addbtn);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.addList);
            this.Name = "addAmigos";
            this.Text = "addAmigos";
            this.Load += new System.EventHandler(this.addAmigos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox addList;
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.Button addbtn;
    }
}