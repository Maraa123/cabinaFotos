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
            this.components = new System.ComponentModel.Container();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.comboBoxCamaras = new System.Windows.Forms.ComboBox();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnTomarFoto = new System.Windows.Forms.Button();
            this.timeContar = new System.Windows.Forms.Timer(this.components);
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnCarpeta = new System.Windows.Forms.Button();
            this.pictureBoxCapturada3 = new System.Windows.Forms.PictureBox();
            this.pictureBoxCapturada2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxCapturada = new System.Windows.Forms.PictureBox();
            this.pictureBoxVideo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCapturada3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCapturada2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCapturada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(67, 270);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 2;
            this.btnImprimir.Text = "IMPRIMIR";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click_1);
            // 
            // comboBoxCamaras
            // 
            this.comboBoxCamaras.FormattingEnabled = true;
            this.comboBoxCamaras.Location = new System.Drawing.Point(25, 33);
            this.comboBoxCamaras.Name = "comboBoxCamaras";
            this.comboBoxCamaras.Size = new System.Drawing.Size(207, 21);
            this.comboBoxCamaras.TabIndex = 3;
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(67, 336);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(75, 23);
            this.btnIniciar.TabIndex = 4;
            this.btnIniciar.Text = "INICIAR";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnTomarFoto
            // 
            this.btnTomarFoto.Location = new System.Drawing.Point(67, 196);
            this.btnTomarFoto.Name = "btnTomarFoto";
            this.btnTomarFoto.Size = new System.Drawing.Size(75, 23);
            this.btnTomarFoto.TabIndex = 5;
            this.btnTomarFoto.Text = "tomar foto";
            this.btnTomarFoto.UseVisualStyleBackColor = true;
            this.btnTomarFoto.Click += new System.EventHandler(this.btnTomarFoto_Click_1);
            // 
            // timeContar
            // 
            this.timeContar.Interval = 1000;
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(67, 127);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(88, 21);
            this.btnGrabar.TabIndex = 8;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click_1);
            // 
            // btnCarpeta
            // 
            this.btnCarpeta.Location = new System.Drawing.Point(25, 78);
            this.btnCarpeta.Name = "btnCarpeta";
            this.btnCarpeta.Size = new System.Drawing.Size(220, 23);
            this.btnCarpeta.TabIndex = 9;
            this.btnCarpeta.Text = "Guardar Foto en Carpeta: ";
            this.btnCarpeta.UseVisualStyleBackColor = true;
            this.btnCarpeta.Click += new System.EventHandler(this.btnCarpeta_Click_1);
            // 
            // pictureBoxCapturada3
            // 
            this.pictureBoxCapturada3.Location = new System.Drawing.Point(1053, 599);
            this.pictureBoxCapturada3.Name = "pictureBoxCapturada3";
            this.pictureBoxCapturada3.Size = new System.Drawing.Size(245, 151);
            this.pictureBoxCapturada3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCapturada3.TabIndex = 17;
            this.pictureBoxCapturada3.TabStop = false;
            // 
            // pictureBoxCapturada2
            // 
            this.pictureBoxCapturada2.Location = new System.Drawing.Point(1053, 336);
            this.pictureBoxCapturada2.Name = "pictureBoxCapturada2";
            this.pictureBoxCapturada2.Size = new System.Drawing.Size(245, 151);
            this.pictureBoxCapturada2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCapturada2.TabIndex = 16;
            this.pictureBoxCapturada2.TabStop = false;
            // 
            // pictureBoxCapturada
            // 
            this.pictureBoxCapturada.Location = new System.Drawing.Point(1053, 104);
            this.pictureBoxCapturada.Name = "pictureBoxCapturada";
            this.pictureBoxCapturada.Size = new System.Drawing.Size(245, 151);
            this.pictureBoxCapturada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCapturada.TabIndex = 15;
            this.pictureBoxCapturada.TabStop = false;
            // 
            // pictureBoxVideo
            // 
            this.pictureBoxVideo.Location = new System.Drawing.Point(328, 104);
            this.pictureBoxVideo.Name = "pictureBoxVideo";
            this.pictureBoxVideo.Size = new System.Drawing.Size(701, 646);
            this.pictureBoxVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxVideo.TabIndex = 18;
            this.pictureBoxVideo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Coral;
            this.label1.Location = new System.Drawing.Point(611, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 108);
            this.label1.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1330, 762);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxVideo);
            this.Controls.Add(this.pictureBoxCapturada3);
            this.Controls.Add(this.pictureBoxCapturada2);
            this.Controls.Add(this.pictureBoxCapturada);
            this.Controls.Add(this.btnCarpeta);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnTomarFoto);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.comboBoxCamaras);
            this.Controls.Add(this.btnImprimir);
            this.Name = "Form1";
            this.Text = "Cabina de Fotos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCapturada3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCapturada2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCapturada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVideo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.ComboBox comboBoxCamaras;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnTomarFoto;
        private System.Windows.Forms.Timer timeContar;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnCarpeta;
        private System.Windows.Forms.PictureBox pictureBoxCapturada3;
        private System.Windows.Forms.PictureBox pictureBoxCapturada2;
        private System.Windows.Forms.PictureBox pictureBoxCapturada;
        private System.Windows.Forms.PictureBox pictureBoxVideo;
        private System.Windows.Forms.Label label1;
    }
}

