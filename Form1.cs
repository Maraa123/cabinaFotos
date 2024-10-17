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

namespace cabinaFotos
{
    public partial class Form1 : Form
    {

        public string Path = @"C:\Users\Mara\Pictures\CAMARA";
        private bool hayDispositivos;
        private FilterInfoCollection MisDispositivos;
        private VideoCaptureDevice MiWebCam;
        private int contadorFotos = 0;
        public Form1()
        {
            InitializeComponent();
        }

        public void CargaDispositivos() {
            MisDispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (MisDispositivos.Count > 0)
            {
                hayDispositivos = true;
                for(int i = 0; i < MisDispositivos.Count; i++)
                    comboBoxCamaras.Items.Add(MisDispositivos[i].Name.ToString());
                comboBoxCamaras.Text = MisDispositivos[0].Name.ToString();
            }
            else  
                hayDispositivos=false;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargaDispositivos();
        }

        private void CerrarWebCam() {

            if (MiWebCam != null && MiWebCam.IsRunning) { 
            
                MiWebCam.SignalToStop();
                MiWebCam = null;
            
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            CerrarWebCam();
            int i = comboBoxCamaras.SelectedIndex;
            string NombreVideo = MisDispositivos[i].MonikerString;
            MiWebCam = new VideoCaptureDevice(NombreVideo);
            MiWebCam.NewFrame += new NewFrameEventHandler(Capturando);
            MiWebCam.Start();

        }

        private void Capturando(object sender, NewFrameEventArgs eventArgs) { 
        Bitmap Imagen = (Bitmap)eventArgs.Frame.Clone();
            pictureBoxVideo.Image = Imagen;
        
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            CerrarWebCam();
        }

        private void btnTomarFoto_Click(object sender, EventArgs e)
        {
            if (MiWebCam != null && MiWebCam.IsRunning)
            {
                pictureBoxCapturada.Image = pictureBoxVideo.Image;

                // Asegurarse de que el usuario haya seleccionado una ruta
                if (string.IsNullOrEmpty(Path))
                {
                    MessageBox.Show("Por favor, seleccione una carpeta para guardar las fotos.");
                    return;
                }

                // Usar la ruta seleccionada y generar un nombre único para el archivo
                string nombreArchivo = System.IO.Path.Combine(Path, "captura_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".jpg");

                pictureBoxCapturada.Image.Save(nombreArchivo, ImageFormat.Jpeg);
                MessageBox.Show("Foto guardada en: " + nombreArchivo);
            }


      /*      if (MiWebCam != null && MiWebCam.IsRunning) {

                contadorFotos++;
                pictureBoxCapturada.Image = pictureBoxVideo.Image;
                pictureBoxCapturada.Image.Save(Path + "\\cabinaFotos_" + contadorFotos + ".jpg", ImageFormat.Jpeg);
            }*/
        }

        private string SeleccionarRutaFotos()
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Seleccione la carpeta donde desea guardar las fotos";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.SelectedPath; // Devolver la ruta seleccionada
                }
                else
                {
                    return null; // Si no se selecciona una carpeta
                }
            }
        }
       

        private void btnCarpeta_Click(object sender, EventArgs e)
        {
            string nuevaRuta = SeleccionarRutaFotos();

            if (!string.IsNullOrEmpty(nuevaRuta))
            {
                Path = nuevaRuta;
                MessageBox.Show("Ruta seleccionada: " + Path);
            }
            else
            {
                MessageBox.Show("No se seleccionó ninguna carpeta.");
            }
        }
    }
}
