using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cabinaFotos
{
    public partial class FormuCamara : Form
    {
        private Camara camara;
        public Action<Bitmap> ImagenCapturadaCallback; // Delegado para enviar la imagen capturada
        private ImprimirGuardar imprimirGuardar = new ImprimirGuardar();

        public FormuCamara() {

            InitializeComponent();
            camara = new Camara();
         
            camara.CargarDispositivos();
            for (int i = 0; i < camara.ObtenerNumeroDispositivos(); i++)
            {
                comboBoxCamaras.Items.Add(camara.ObtenerNombreDispositivo(i));
            }
            if (comboBoxCamaras.Items.Count > 0)
                comboBoxCamaras.SelectedIndex = 0;
           
        }


        private void btnFondo_Click(object sender, EventArgs e)
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

        private void btnLogo_Click(object sender, EventArgs e)
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

        private void btnCarpeta_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK) { 
            textBox1.Text = dialog.SelectedPath;
            }

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
           
            int indexDispositivo = comboBoxCamaras.SelectedIndex; // Obtiene el índice de la cámara seleccionada
          //  camara.IniciarCamara(indexDispositivo); // Llama al método para iniciar la cámara

            Form1 form1 = new Form1(); // Crear una nueva instancia del formulario
            form1.Show(); // Mostrar como un cuadro de diálogo modal


        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
                imprimirGuardar.ImprimirGroupBox(groupBox1);
                imprimirGuardar.GuardarGroupBoxEnCarpeta(groupBox1);  // Guarda `groupBox1` en la ruta especificada en `Path`.
            
        }

        private void FormuCamara_Load(object sender, EventArgs e)
        {
            imprimirGuardar.CargarImpresoras(comboBoxImpresoras);
        }
    }
}
