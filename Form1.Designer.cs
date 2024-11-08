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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timeContar = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pLANTILLAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fondoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fotoDeCarpetaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBoxCamaras = new System.Windows.Forms.ToolStripComboBox();
            this.grabarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pLANTILLAToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fondoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expandirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxCapturada = new System.Windows.Forms.PictureBox();
            this.pictureBoxCapturada3 = new System.Windows.Forms.PictureBox();
            this.pictureBoxCapturada2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxVideo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTomarFoto = new System.Windows.Forms.Button();
            this.btnImprimirRapido = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCapturada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCapturada3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCapturada2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // timeContar
            // 
            this.timeContar.Interval = 1000;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1285, 28);
            this.menuStrip1.TabIndex = 30;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pLANTILLAToolStripMenuItem,
            this.fondoToolStripMenuItem1,
            this.fotoDeCarpetaToolStripMenuItem,
            this.comboBoxCamaras,
            this.grabarToolStripMenuItem,
            this.imprimirToolStripMenuItem,
            this.pLANTILLAToolStripMenuItem1,
            this.fondoToolStripMenuItem,
            this.logoToolStripMenuItem,
            this.expandirToolStripMenuItem});
            this.menuToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // pLANTILLAToolStripMenuItem
            // 
            this.pLANTILLAToolStripMenuItem.BackColor = System.Drawing.Color.IndianRed;
            this.pLANTILLAToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pLANTILLAToolStripMenuItem.Name = "pLANTILLAToolStripMenuItem";
            this.pLANTILLAToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.pLANTILLAToolStripMenuItem.Text = "GENERAL";
            // 
            // fondoToolStripMenuItem1
            // 
            this.fondoToolStripMenuItem1.Image = global::cabinaFotos.Properties.Resources.imagen;
            this.fondoToolStripMenuItem1.Name = "fondoToolStripMenuItem1";
            this.fondoToolStripMenuItem1.Size = new System.Drawing.Size(205, 26);
            this.fondoToolStripMenuItem1.Text = "Fondo atras";
            this.fondoToolStripMenuItem1.Click += new System.EventHandler(this.fondoToolStripMenuItem1_Click);
            // 
            // fotoDeCarpetaToolStripMenuItem
            // 
            this.fotoDeCarpetaToolStripMenuItem.Image = global::cabinaFotos.Properties.Resources.carpeta;
            this.fotoDeCarpetaToolStripMenuItem.Name = "fotoDeCarpetaToolStripMenuItem";
            this.fotoDeCarpetaToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.fotoDeCarpetaToolStripMenuItem.Text = "Guardar en carpeta";
            this.fotoDeCarpetaToolStripMenuItem.Click += new System.EventHandler(this.fotoDeCarpetaToolStripMenuItem_Click);
            // 
            // comboBoxCamaras
            // 
            this.comboBoxCamaras.Name = "comboBoxCamaras";
            this.comboBoxCamaras.Size = new System.Drawing.Size(121, 23);
            // 
            // grabarToolStripMenuItem
            // 
            this.grabarToolStripMenuItem.Image = global::cabinaFotos.Properties.Resources.boton_rec;
            this.grabarToolStripMenuItem.Name = "grabarToolStripMenuItem";
            this.grabarToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.grabarToolStripMenuItem.Text = "Grabar";
            this.grabarToolStripMenuItem.Click += new System.EventHandler(this.grabarToolStripMenuItem_Click);
            // 
            // imprimirToolStripMenuItem
            // 
            this.imprimirToolStripMenuItem.Image = global::cabinaFotos.Properties.Resources.imprimir;
            this.imprimirToolStripMenuItem.Name = "imprimirToolStripMenuItem";
            this.imprimirToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.imprimirToolStripMenuItem.Text = "Imprimir";
            this.imprimirToolStripMenuItem.Click += new System.EventHandler(this.imprimirToolStripMenuItem_Click);
            // 
            // pLANTILLAToolStripMenuItem1
            // 
            this.pLANTILLAToolStripMenuItem1.BackColor = System.Drawing.Color.IndianRed;
            this.pLANTILLAToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pLANTILLAToolStripMenuItem1.Name = "pLANTILLAToolStripMenuItem1";
            this.pLANTILLAToolStripMenuItem1.Size = new System.Drawing.Size(205, 26);
            this.pLANTILLAToolStripMenuItem1.Text = "PLANTILLA";
            // 
            // fondoToolStripMenuItem
            // 
            this.fondoToolStripMenuItem.Image = global::cabinaFotos.Properties.Resources.foto;
            this.fondoToolStripMenuItem.Name = "fondoToolStripMenuItem";
            this.fondoToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.fondoToolStripMenuItem.Text = "Fondo";
            this.fondoToolStripMenuItem.Click += new System.EventHandler(this.fondoToolStripMenuItem_Click);
            // 
            // logoToolStripMenuItem
            // 
            this.logoToolStripMenuItem.Image = global::cabinaFotos.Properties.Resources.imagen__2_1;
            this.logoToolStripMenuItem.Name = "logoToolStripMenuItem";
            this.logoToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.logoToolStripMenuItem.Text = "Logo";
            this.logoToolStripMenuItem.Click += new System.EventHandler(this.logoToolStripMenuItem_Click);
            // 
            // expandirToolStripMenuItem
            // 
            this.expandirToolStripMenuItem.Name = "expandirToolStripMenuItem";
            this.expandirToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.expandirToolStripMenuItem.Text = "expandir";
            this.expandirToolStripMenuItem.Click += new System.EventHandler(this.expandirToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundImage = global::cabinaFotos.Properties.Resources._2149876014__1_;
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.pictureBoxCapturada);
            this.groupBox1.Controls.Add(this.pictureBoxCapturada3);
            this.groupBox1.Controls.Add(this.pictureBoxCapturada2);
            this.groupBox1.ForeColor = System.Drawing.Color.Transparent;
            this.groupBox1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.groupBox1.Location = new System.Drawing.Point(735, 204);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(528, 350);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::cabinaFotos.Properties.Resources.rb_2148490649;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(278, 183);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(235, 144);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBoxCapturada
            // 
            this.pictureBoxCapturada.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxCapturada.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxCapturada.Location = new System.Drawing.Point(23, 24);
            this.pictureBoxCapturada.Name = "pictureBoxCapturada";
            this.pictureBoxCapturada.Size = new System.Drawing.Size(235, 144);
            this.pictureBoxCapturada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCapturada.TabIndex = 21;
            this.pictureBoxCapturada.TabStop = false;
            // 
            // pictureBoxCapturada3
            // 
            this.pictureBoxCapturada3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxCapturada3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxCapturada3.Location = new System.Drawing.Point(23, 183);
            this.pictureBoxCapturada3.Name = "pictureBoxCapturada3";
            this.pictureBoxCapturada3.Size = new System.Drawing.Size(235, 144);
            this.pictureBoxCapturada3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCapturada3.TabIndex = 23;
            this.pictureBoxCapturada3.TabStop = false;
            // 
            // pictureBoxCapturada2
            // 
            this.pictureBoxCapturada2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxCapturada2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxCapturada2.Location = new System.Drawing.Point(278, 24);
            this.pictureBoxCapturada2.Name = "pictureBoxCapturada2";
            this.pictureBoxCapturada2.Size = new System.Drawing.Size(235, 144);
            this.pictureBoxCapturada2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCapturada2.TabIndex = 22;
            this.pictureBoxCapturada2.TabStop = false;
            // 
            // pictureBoxVideo
            // 
            this.pictureBoxVideo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxVideo.Location = new System.Drawing.Point(60, 105);
            this.pictureBoxVideo.Name = "pictureBoxVideo";
            this.pictureBoxVideo.Size = new System.Drawing.Size(600, 500);
            this.pictureBoxVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxVideo.TabIndex = 27;
            this.pictureBoxVideo.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Coral;
            this.label1.Location = new System.Drawing.Point(59, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(616, 102);
            this.label1.TabIndex = 31;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTomarFoto
            // 
            this.btnTomarFoto.BackColor = System.Drawing.Color.Transparent;
            this.btnTomarFoto.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnTomarFoto.Image = global::cabinaFotos.Properties.Resources.boton_rec;
            this.btnTomarFoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTomarFoto.Location = new System.Drawing.Point(1123, 645);
            this.btnTomarFoto.Name = "btnTomarFoto";
            this.btnTomarFoto.Size = new System.Drawing.Size(56, 27);
            this.btnTomarFoto.TabIndex = 24;
            this.btnTomarFoto.Text = "Foto";
            this.btnTomarFoto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTomarFoto.UseVisualStyleBackColor = false;
            this.btnTomarFoto.Click += new System.EventHandler(this.btnTomarFoto_Click);
            // 
            // btnImprimirRapido
            // 
            this.btnImprimirRapido.BackColor = System.Drawing.Color.Transparent;
            this.btnImprimirRapido.Image = global::cabinaFotos.Properties.Resources.imprimir;
            this.btnImprimirRapido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimirRapido.Location = new System.Drawing.Point(1194, 645);
            this.btnImprimirRapido.Name = "btnImprimirRapido";
            this.btnImprimirRapido.Size = new System.Drawing.Size(69, 27);
            this.btnImprimirRapido.TabIndex = 32;
            this.btnImprimirRapido.Text = "Imprimir";
            this.btnImprimirRapido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimirRapido.UseVisualStyleBackColor = false;
            this.btnImprimirRapido.Click += new System.EventHandler(this.btnImprimirRapido_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1285, 699);
            this.Controls.Add(this.btnImprimirRapido);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBoxVideo);
            this.Controls.Add(this.btnTomarFoto);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Cabina de Fotos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed_1);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCapturada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCapturada3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCapturada2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVideo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timeContar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBoxCapturada;
        private System.Windows.Forms.PictureBox pictureBoxCapturada3;
        private System.Windows.Forms.PictureBox pictureBoxCapturada2;
        private System.Windows.Forms.PictureBox pictureBoxVideo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pLANTILLAToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox comboBoxCamaras;
        private System.Windows.Forms.ToolStripMenuItem fotoDeCarpetaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grabarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pLANTILLAToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fondoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fondoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTomarFoto;
        private System.Windows.Forms.ToolStripMenuItem expandirToolStripMenuItem;
        private System.Windows.Forms.Button btnImprimirRapido;
    }
}

