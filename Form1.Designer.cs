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
            this.pictureBoxVideo = new System.Windows.Forms.PictureBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.comboBoxCamaras = new System.Windows.Forms.ComboBox();
            this.btnDetener = new System.Windows.Forms.Button();
            this.btnTomarFoto = new System.Windows.Forms.Button();
            this.label1Contar = new System.Windows.Forms.Label();
            this.timeContar = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxCapturada = new System.Windows.Forms.PictureBox();
            this.btnGrabar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVideo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCapturada)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxVideo
            // 
            this.pictureBoxVideo.Location = new System.Drawing.Point(25, 71);
            this.pictureBoxVideo.Name = "pictureBoxVideo";
            this.pictureBoxVideo.Size = new System.Drawing.Size(605, 555);
            this.pictureBoxVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxVideo.TabIndex = 1;
            this.pictureBoxVideo.TabStop = false;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(272, 683);
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
            this.comboBoxCamaras.Size = new System.Drawing.Size(207, 21);
            this.comboBoxCamaras.TabIndex = 3;
            // 
            // btnDetener
            // 
            this.btnDetener.Location = new System.Drawing.Point(25, 673);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(75, 23);
            this.btnDetener.TabIndex = 4;
            this.btnDetener.Text = "Detener";
            this.btnDetener.UseVisualStyleBackColor = true;
            // 
            // btnTomarFoto
            // 
            this.btnTomarFoto.Location = new System.Drawing.Point(796, 31);
            this.btnTomarFoto.Name = "btnTomarFoto";
            this.btnTomarFoto.Size = new System.Drawing.Size(75, 23);
            this.btnTomarFoto.TabIndex = 5;
            this.btnTomarFoto.Text = "tomar foto";
            this.btnTomarFoto.UseVisualStyleBackColor = true;
            this.btnTomarFoto.Click += new System.EventHandler(this.btnTomarFoto_Click);
            // 
            // label1Contar
            // 
            this.label1Contar.AutoSize = true;
            this.label1Contar.BackColor = System.Drawing.SystemColors.Menu;
            this.label1Contar.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1Contar.ForeColor = System.Drawing.Color.Red;
            this.label1Contar.Location = new System.Drawing.Point(664, 183);
            this.label1Contar.Name = "label1Contar";
            this.label1Contar.Size = new System.Drawing.Size(0, 108);
            this.label1Contar.TabIndex = 6;
            // 
            // timeContar
            // 
            this.timeContar.Interval = 1000;
            // 
            // pictureBoxCapturada
            // 
            this.pictureBoxCapturada.Location = new System.Drawing.Point(796, 62);
            this.pictureBoxCapturada.Name = "pictureBoxCapturada";
            this.pictureBoxCapturada.Size = new System.Drawing.Size(543, 564);
            this.pictureBoxCapturada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCapturada.TabIndex = 7;
            this.pictureBoxCapturada.TabStop = false;
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(272, 33);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(88, 21);
            this.btnGrabar.TabIndex = 8;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1447, 730);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.pictureBoxCapturada);
            this.Controls.Add(this.label1Contar);
            this.Controls.Add(this.btnTomarFoto);
            this.Controls.Add(this.btnDetener);
            this.Controls.Add(this.comboBoxCamaras);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.pictureBoxVideo);
            this.Name = "Form1";
            this.Text = "Cabina de Fotos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVideo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCapturada)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxVideo;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.ComboBox comboBoxCamaras;
        private System.Windows.Forms.Button btnDetener;
        private System.Windows.Forms.Button btnTomarFoto;
        private System.Windows.Forms.Label label1Contar;
        private System.Windows.Forms.Timer timeContar;
        private System.Windows.Forms.PictureBox pictureBoxCapturada;
        private System.Windows.Forms.Button btnGrabar;
    }
}

