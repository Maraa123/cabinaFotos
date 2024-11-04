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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace cabinaFotos
{
    public partial class Form1 : Form
    {
        private string camaraSeleccionada; // Variable para almacenar el nombre de la cámara

        private Camara camara;
        private FormuCamara ventanaCamara;
        private ImprimirGuardar imprimirGuardar = new ImprimirGuardar();
        public Form1()
        {
            InitializeComponent();
            camara = new Camara();
          
            //      camaraSeleccionada = camara; // Guarda la cámara seleccionada
            camara.CargarDispositivos();
            for (int i = 0; i < camara.ObtenerNumeroDispositivos(); i++)
            {
                comboBoxCamaras.Items.Add(camara.ObtenerNombreDispositivo(i));
            }
            if (comboBoxCamaras.Items.Count > 0)
                comboBoxCamaras.SelectedIndex = 0;

        }


        private void btnTomarFoto_Click(object sender, EventArgs e)
        {
            PictureBox[] pictureBoxes = { pictureBoxCapturada, pictureBoxCapturada2, pictureBoxCapturada3 }; // Asegúrate de que estos PictureBox existan
            camara.IniciarContador(label1, pictureBoxVideo, pictureBoxes);


        }

        private void Form1_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            camara.CerrarWebCam(); // Llama a la función de la clase Camara
        }

        private void fotoDeCarpetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nuevaRuta = imprimirGuardar.SeleccionarRutaFotos();
            if (!string.IsNullOrEmpty(nuevaRuta))
            {
                imprimirGuardar.EstablecerRuta(nuevaRuta);
            }
        }

        private void grabarToolStripMenuItem_Click(object sender, EventArgs e)
        {
             camara.IniciarCamara(comboBoxCamaras.SelectedIndex, pictureBoxVideo);
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  imprimirGuardar.ImprimirGroupBox(groupBox1);
            //imprimirGuardar.GuardarGroupBoxEnCarpeta(groupBox1);  // Guarda `groupBox1` en la ruta especificada en `Path`.

        }


        private void fondoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = "Seleccione una Imagen para el Formulario";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image fondoImagen = Image.FromFile(openFileDialog.FileName);
                this.BackgroundImage = fondoImagen;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void expandirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.Sizable;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IniciarCamara(camaraSeleccionada);
        }
        private void IniciarCamara(string camara)
        {
            // Aquí deberías tener la lógica para iniciar la cámara
            // Suponiendo que tienes un objeto de tipo Camara en Form2
            Camara camaraObj = new Camara();

            // Cargar dispositivos y encontrar el dispositivo seleccionado
            camaraObj.CargarDispositivos();

            // Encontrar el índice de la cámara seleccionada
            for (int i = 0; i < camaraObj.ObtenerNumeroDispositivos(); i++)
            {
                if (camaraObj.ObtenerNombreDispositivo(i) == camara)
                {
                    // Iniciar la cámara en el índice encontrado
          //          camaraObj.Abrir(i); // Asegúrate de tener un método Abrir en tu clase Camara
                    break; // Salir del bucle una vez que se haya encontrado
                }
            }
        }

        private void comboBoxCamaras_Click(object sender, EventArgs e)
        {

        }
    }
}