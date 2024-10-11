namespace cabinaFotos
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
            this.BtnCapturar = new System.Windows.Forms.Button();
            this.pictureBoxVideo = new System.Windows.Forms.PictureBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.comboBoxCamaras = new System.Windows.Forms.ComboBox();
            this.btnDetener = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnCapturar
            // 
            this.BtnCapturar.Location = new System.Drawing.Point(136, 327);
            this.BtnCapturar.Name = "BtnCapturar";
            this.BtnCapturar.Size = new System.Drawing.Size(75, 23);
            this.BtnCapturar.TabIndex = 0;
            this.BtnCapturar.Text = "CAPTURAR";
            this.BtnCapturar.UseVisualStyleBackColor = true;
            this.BtnCapturar.Click += new System.EventHandler(this.BtnCapturar_Click);
            // 
            // pictureBoxVideo
            // 
            this.pictureBoxVideo.Location = new System.Drawing.Point(127, 60);
            this.pictureBoxVideo.Name = "pictureBoxVideo";
            this.pictureBoxVideo.Size = new System.Drawing.Size(244, 221);
            this.pictureBoxVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxVideo.TabIndex = 1;
            this.pictureBoxVideo.TabStop = false;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(215, 400);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 2;
            this.btnImprimir.Text = "IMPRIMIR";
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // comboBoxCamaras
            // 
            this.comboBoxCamaras.FormattingEnabled = true;
            this.comboBoxCamaras.Location = new System.Drawing.Point(25, 33);
            this.comboBoxCamaras.Name = "comboBoxCamaras";
            this.comboBoxCamaras.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCamaras.TabIndex = 3;
            this.comboBoxCamaras.SelectedIndexChanged += new System.EventHandler(this.comboBoxCamaras_SelectedIndexChanged);
            // 
            // btnDetener
            // 
            this.btnDetener.Location = new System.Drawing.Point(262, 327);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(75, 23);
            this.btnDetener.TabIndex = 4;
            this.btnDetener.Text = "Detener";
            this.btnDetener.UseVisualStyleBackColor = true;
            this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 595);
            this.Controls.Add(this.btnDetener);
            this.Controls.Add(this.comboBoxCamaras);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.pictureBoxVideo);
            this.Controls.Add(this.BtnCapturar);
            this.Name = "Form1";
            this.Text = "Cabina de Fotos";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVideo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnCapturar;
        private System.Windows.Forms.PictureBox pictureBoxVideo;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.ComboBox comboBoxCamaras;
        private System.Windows.Forms.Button btnDetener;
    }
}

