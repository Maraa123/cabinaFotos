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
        private Camara camaraManager;

        public Form1()
        {
            InitializeComponent();
            InicializarCamaraManager();
        }

        /// <summary>
        /// Inicializa la instancia de CamaraManager y configura eventos.
        /// </summary>
        private void InicializarCamaraManager()
        {
            camaraManager = new Camara();
            camaraManager.OnNewFrame += CamaraManager_OnNewFrame;
            camaraManager.OnError += CamaraManager_OnError;

            // Llenar el ComboBox con las cámaras disponibles
            string[] camaras = camaraManager.ObtenerCamarasDisponibles();
            if (camaras.Length > 0)
            {
                comboBoxCamaras.Items.AddRange(camaras);
                comboBoxCamaras.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No se encontraron cámaras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el evento de nuevo cuadro de video.
        /// </summary>
        private void CamaraManager_OnNewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Asegurarse de que la actualización de la UI se realice en el hilo principal
            if (pictureBoxVideo.InvokeRequired)
            {
                pictureBoxVideo.Invoke(new Action(() =>
                {
                    pictureBoxVideo.Image?.Dispose();
                    pictureBoxVideo.Image = (Bitmap)eventArgs.Frame.Clone();
                }));
            }
            else
            {
                pictureBoxVideo.Image?.Dispose();
                pictureBoxVideo.Image = (Bitmap)eventArgs.Frame.Clone();
            }
        }

        /// <summary>
        /// Maneja el evento de error de la cámara.
        /// </summary>
        private void CamaraManager_OnError(object sender, EventArgs e)
        {
            MessageBox.Show("Ocurrió un error con la cámara.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Evento al cambiar la selección de la cámara en el ComboBox.
        /// </summary>
        private void comboBoxCamaras_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                camaraManager.IniciarCamara(comboBoxCamaras.SelectedIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar la cámara: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento al hacer clic en el botón Capturar.
        /// </summary>
        private void btnCapturar_Click(object sender, EventArgs e)
        {
            if (pictureBoxVideo.Image != null)
            {
                Bitmap captura = (Bitmap)pictureBoxVideo.Image.Clone();
                string rutaGuardado = $"captura_{DateTime.Now:yyyyMMdd_HHmmss}.jpg";

                try
                {
                    captura.Save(rutaGuardado, System.Drawing.Imaging.ImageFormat.Jpeg);
                    MessageBox.Show($"Imagen capturada y guardada como {rutaGuardado}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    captura.Dispose();
                }
            }
            else
            {
                MessageBox.Show("No hay imagen para capturar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Evento al hacer clic en el botón Detener Cámara.
        /// </summary>
        private void btnDetener_Click(object sender, EventArgs e)
        {
            camaraManager.DetenerCamara();
            pictureBoxVideo.Image = null;
        }

        /// <summary>
        /// Asegura que la cámara se detenga al cerrar el formulario.
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            camaraManager.DetenerCamara();
            base.OnFormClosing(e);
        }
    }
}
