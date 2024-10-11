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

namespace cabinaFotos
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;

        private FilterInfoCollection dispositivosVideo;
        private VideoCaptureDevice fuenteVideo;

        public Form1()
        {
            InitializeComponent();
            EnumerarCamaras();
        }

        private void EnumerarCamaras()
        {
            // Obtener la colección de dispositivos de video
            dispositivosVideo = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (dispositivosVideo.Count == 0)
            {
                MessageBox.Show("No se encontraron cámaras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Agregar cada dispositivo al ComboBox
            foreach (FilterInfo dispositivo in dispositivosVideo)
            {
                comboBoxCamaras.Items.Add(dispositivo.Name);
            }

            // Seleccionar el primer dispositivo por defecto
            comboBoxCamaras.SelectedIndex = 0;
        }

        private void comboBoxCamaras_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Detener cualquier fuente de video previa
            if (fuenteVideo != null && fuenteVideo.IsRunning)
            {
                fuenteVideo.SignalToStop();
                fuenteVideo = null;
            }

            // Obtener el dispositivo seleccionado
            int indiceSeleccionado = comboBoxCamaras.SelectedIndex;
            if (indiceSeleccionado >= 0)
            {
                fuenteVideo = new VideoCaptureDevice(dispositivosVideo[indiceSeleccionado].MonikerString);
                fuenteVideo.NewFrame += new NewFrameEventHandler(fuenteVideo_NewFrame);
                fuenteVideo.Start();
            }
        }

        private void fuenteVideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Mostrar la imagen en el PictureBox
            Bitmap imagen = (Bitmap)eventArgs.Frame.Clone();
            pictureBoxVideo.Image = imagen;
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            if (fuenteVideo != null && fuenteVideo.IsRunning)
            {
                fuenteVideo.SignalToStop();
                fuenteVideo = null;
                pictureBoxVideo.Image = null;
            }
        }

        private void BtnCapturar_Click(object sender, EventArgs e)
        {
            if (pictureBoxVideo.Image != null)
            {
                // Clonar la imagen actual
                Bitmap captura = (Bitmap)pictureBoxVideo.Image.Clone();

                // Definir la ruta donde se guardará la imagen
                string rutaGuardado = $"captura_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.jpg";

                try
                {
                    // Guardar la imagen en formato JPEG
                    captura.Save(rutaGuardado, System.Drawing.Imaging.ImageFormat.Jpeg);
                    MessageBox.Show($"Imagen capturada y guardada como {rutaGuardado}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No hay imagen para capturar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

            protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (fuenteVideo != null && fuenteVideo.IsRunning)
            {
                fuenteVideo.SignalToStop();
                fuenteVideo = null;
            }
            base.OnFormClosing(e);
        }

    }
}





