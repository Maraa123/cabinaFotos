using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AForge.Video;
using System.Diagnostics.Tracing;
using System.Drawing.Imaging;

using System.Drawing.Printing;

namespace cabinaFotos{
    public partial class Form1 : Form  {

        private Camara camara;
        private FormuCamara ventanaCamara;

        public Form1() {
      //    this.WindowState = FormWindowState.Maximized; // Para maximizar
     //     this.FormBorderStyle = FormBorderStyle.None; // Para quitar bordes

            InitializeComponent();  // Solo debe ir una vez.
            camara = new Camara();
            camara.CargarDispositivos();

            // Llenar comboBox con las cámaras disponibles
            for (int i = 0; i < camara.ObtenerNumeroDispositivos(); i++) {
                comboBoxCamaras.Items.Add(camara.ObtenerNombreDispositivo(i));
            }
            if (comboBoxCamaras.Items.Count > 0)
                comboBoxCamaras.SelectedIndex = 0;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            // Crear una instancia de FormuCamara pasando la misma instancia de la clase Camara
            ventanaCamara = new FormuCamara();
            ventanaCamara.ShowDialog(); // Mostrar el FormuCamara
        }

        public void ImprimirImagen()  {
            if (pictureBoxCapturada.Image != null)  {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(ImprimirPagina);
                PrintDialog printDialog = new PrintDialog();

                // Asignar el documento de impresión
                printDialog.Document = pd;

                // Mostrar el cuadro de diálogo de impresión
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    pd.Print(); // Imprimir la imagen
                }
            }
            else {
                MessageBox.Show("No hay imagen capturada para imprimir.");
            }
        }

        private void ImprimirPagina(object sender, PrintPageEventArgs e){
            if (pictureBoxCapturada.Image != null) {
                // Obtener la imagen a imprimir
                Image imagenAImprimir = pictureBoxCapturada.Image;

                // Ajustar la imagen al tamaño de la página
                Rectangle m = e.MarginBounds;

                // Escalar la imagen si es necesario
                if ((double)imagenAImprimir.Width / (double)imagenAImprimir.Height > (double)m.Width / (double)m.Height){
                    m.Height = (int)((double)imagenAImprimir.Height / (double)imagenAImprimir.Width * (double)m.Width);
                }
                else{
                    m.Width = (int)((double)imagenAImprimir.Width / (double)imagenAImprimir.Height * (double)m.Height);
                }
                // Dibujar la imagen en la página de impresión
                e.Graphics.DrawImage(imagenAImprimir, m);
            }
        }

        private void btnTomarFoto_Click_1(object sender, EventArgs e)  {
            PictureBox[] pictureBoxes = { pictureBoxCapturada, pictureBoxCapturada2, pictureBoxCapturada3 }; // Asegúrate de que estos PictureBox existan
            camara.IniciarContador(label1, pictureBoxVideo, pictureBoxes);

        }

        private void btnCarpeta_Click_1(object sender, EventArgs e){
            string nuevaRuta = camara.SeleccionarRutaFotos();
            if (!string.IsNullOrEmpty(nuevaRuta))
            {
                camara.EstablecerRuta(nuevaRuta);
            }
        }
        private void btnGrabar_Click_1(object sender, EventArgs e) {
            camara.IniciarCamara(comboBoxCamaras.SelectedIndex, pictureBoxVideo);
        }

        private void btnImprimir_Click_1(object sender, EventArgs e)  {
            ImprimirImagen();
        }

        private void Form1_FormClosed_1(object sender, FormClosedEventArgs e) {
            camara.CerrarWebCam(); // Llama a la función de la clase Camara
        }
    }
}