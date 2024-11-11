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

        private Camara camara;
        private Size originalFormSize;
        private Dictionary<Control, Rectangle> originalControlSizes = new Dictionary<Control, Rectangle>();


        private ImprimirGuardar imprimirGuardar = new ImprimirGuardar();
        public Form1()
        {

            InitializeComponent();  
            camara = new Camara();
            camara.CargarDispositivos();

           
            for (int i = 0; i < camara.ObtenerNumeroDispositivos(); i++)
            {
                comboBoxCamaras.Items.Add(camara.ObtenerNombreDispositivo(i));
            }
            if (comboBoxCamaras.Items.Count > 0)
                comboBoxCamaras.SelectedIndex = 0;

            // Guarda el tamaño original del formulario
            originalFormSize = this.Size;

            // Guarda el tamaño y posición de todos los controles (anidados también)
            SaveOriginalControlSizes(this);

            // Vincula el evento Resize para redimensionar controles al cambiar tamaño de formulario
            this.Resize += Form1_Resize;



            imprimirGuardar = new ImprimirGuardar();
            camara.CapturaFinalizada += () =>
            {
                // Llama al método de impresión cuando finalice la captura
                imprimirGuardar.ImprimirDirectamente(groupBox1);
            };






        }

        // Método para guardar tamaños y posiciones originales de todos los controles
        private void SaveOriginalControlSizes(Control container)
        {
            foreach (Control ctrl in container.Controls)
            {
                originalControlSizes[ctrl] = new Rectangle(ctrl.Location, ctrl.Size);

                // Llama recursivamente para guardar los controles anidados
                if (ctrl.Controls.Count > 0)
                {
                    SaveOriginalControlSizes(ctrl);
                }
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            float widthRatio = (float)this.Width / originalFormSize.Width;
            float heightRatio = (float)this.Height / originalFormSize.Height;

            ResizeAllControls(this, widthRatio, heightRatio);
        }

        // Redimensiona todos los controles recursivamente
        private void ResizeAllControls(Control container, float widthRatio, float heightRatio)
        {
            foreach (Control ctrl in container.Controls)
            {
                if (originalControlSizes.ContainsKey(ctrl))
                {
                    Rectangle originalRect = originalControlSizes[ctrl];

                    ctrl.Width = (int)(originalRect.Width * widthRatio);
                    ctrl.Height = (int)(originalRect.Height * heightRatio);
                    ctrl.Left = (int)(originalRect.Left * widthRatio);
                    ctrl.Top = (int)(originalRect.Top * heightRatio);
                }

                if (ctrl.Controls.Count > 0)
                {
                    ResizeAllControls(ctrl, widthRatio, heightRatio);
                }
            }
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
            imprimirGuardar.ImprimirGroupBox(groupBox1);
            imprimirGuardar.GuardarGroupBoxEnCarpeta(groupBox1);  // Guarda `groupBox1` en la ruta especificada en `Path`.
        }

        private void fondoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crear y configurar el cuadro de diálogo para seleccionar archivos
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = "Seleccione una Imagen";

            // Mostrar el cuadro de diálogo y verificar que el usuario haya seleccionado un archivo
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Cargar la imagen seleccionada
                Image fondoImagen = Image.FromFile(openFileDialog.FileName);

                // Establecer la imagen como fondo del GroupBox
                groupBox1.BackgroundImage = fondoImagen;
                groupBox1.BackgroundImageLayout = ImageLayout.Stretch; // Ajustar la imagen al tamaño del GroupBox
            }

        }

        private void logoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = "Seleccione una Imagen";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image fondoImagen = Image.FromFile(openFileDialog.FileName);

                pictureBox1.BackgroundImage = fondoImagen;
                pictureBox1.BackgroundImageLayout = ImageLayout.Stretch; 
            }
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

        }

        private void btnImprimirRapido_Click(object sender, EventArgs e)
        {
            imprimirGuardar.ImprimirDirectamente(groupBox1); 
        }

        }
    }
