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

namespace cabinaFotos
{
    public partial class Form1 : Form
    {

        private Camara camara;
        private FormuCamara ventanaCamara;

        public Form1()
        {
            //    this.WindowState = FormWindowState.Maximized; // Para maximizar
            //     this.FormBorderStyle = FormBorderStyle.None; // Para quitar bordes

            InitializeComponent();  // Solo debe ir una vez.
            camara = new Camara();
            camara.CargarDispositivos();

            // Llenar comboBox con las cámaras disponibles
            for (int i = 0; i < camara.ObtenerNumeroDispositivos(); i++)
            {
                comboBoxCamaras.Items.Add(camara.ObtenerNombreDispositivo(i));
            }
            if (comboBoxCamaras.Items.Count > 0)
                comboBoxCamaras.SelectedIndex = 0;
        }

        private void btnIniciar_Click_1(object sender, EventArgs e)
        {
            // Crear una instancia de FormuCamara pasando la misma instancia de la clase Camara
            ventanaCamara = new FormuCamara();
            ventanaCamara.ShowDialog(); 

        }

        //imprimir 

        // Método para capturar el contenido de un control 
        private Bitmap CapturarControl(Control control)
        {
            Bitmap bmp = new Bitmap(control.Width, control.Height);
            control.DrawToBitmap(bmp, new Rectangle(0, 0, control.Width, control.Height));
            return bmp;
        }

        public void ImprimirGroupBox()
        {
            // Capturar la imagen del GroupBox
            Bitmap groupBoxImagen = CapturarControl(groupBox1);

            if (groupBoxImagen != null)
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += (sender, e) => ImprimirPagina(sender, e, groupBoxImagen);
                PrintDialog printDialog = new PrintDialog();

                // Asignar el documento de impresión
                printDialog.Document = pd;

                // Mostrar el cuadro de diálogo de impresión
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    pd.Print(); // Imprimir el contenido capturado del GroupBox
                }
            }
            else
            {
                MessageBox.Show("No hay contenido en el GroupBox para imprimir.");
            }
        }

        // Método que maneja la impresión
        private void ImprimirPagina(object sender, PrintPageEventArgs e, Bitmap imagenAImprimir)
        {
            e.PageSettings.Landscape = true;

            // Definir tamaño A6 en puntos (96 puntos por pulgada)
            float a5WidthPoints = 4.13f * 96;
            float a5HeightPoints = 5.83f * 96;

            // Escalar la imagen del GroupBox al tamaño A5
            RectangleF printArea = new RectangleF(0, 0, a5WidthPoints, a5HeightPoints);

            // Dibujar la imagen en la página de impresión
            e.Graphics.DrawImage(imagenAImprimir, printArea);
        }



        public void ImprimirImagen()
        {
            if (pictureBoxCapturada.Image != null)
            {
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
            else
            {
                MessageBox.Show("No hay imagen capturada para imprimir.");
            }
        }

        private void ImprimirPagina(object sender, PrintPageEventArgs e)
        {
            if (pictureBoxCapturada.Image != null)
            {
                // Obtener la imagen a imprimir
                Image imagenAImprimir = pictureBoxCapturada.Image;

                // Ajustar la imagen al tamaño de la página
                Rectangle m = e.MarginBounds;

                // Escalar la imagen si es necesario
                if ((double)imagenAImprimir.Width / (double)imagenAImprimir.Height > (double)m.Width / (double)m.Height)
                {
                    m.Height = (int)((double)imagenAImprimir.Height / (double)imagenAImprimir.Width * (double)m.Width);
                }
                else
                {
                    m.Width = (int)((double)imagenAImprimir.Width / (double)imagenAImprimir.Height * (double)m.Height);
                }
                // Dibujar la imagen en la página de impresión
                e.Graphics.DrawImage(imagenAImprimir, m);
            }
        }

     

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ImprimirGroupBox();
        }


        private void btnTomarFoto_Click(object sender, EventArgs e)
        {
            PictureBox[] pictureBoxes = { pictureBoxCapturada, pictureBoxCapturada2, pictureBoxCapturada3 }; // Asegúrate de que estos PictureBox existan
            camara.IniciarContador(label1, pictureBoxVideo, pictureBoxes);


        }
       
        private void btnCarpeta_Click(object sender, EventArgs e)
        {
            string nuevaRuta = camara.SeleccionarRutaFotos();
            if (!string.IsNullOrEmpty(nuevaRuta))
            {
                camara.EstablecerRuta(nuevaRuta);
            }
        }


        private void btnGrabar_Click(object sender, EventArgs e)
        {
            camara.IniciarCamara(comboBoxCamaras.SelectedIndex, pictureBoxVideo);
        }


        private void Form1_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            camara.CerrarWebCam(); // Llama a la función de la clase Camara
        }

       
    }
}