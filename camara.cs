using AForge.Video.DirectShow;
using AForge.Video;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace cabinaFotos
{
    class Camara
    {
        private FilterInfoCollection MisDispositivos;
        private VideoCaptureDevice MiWebCam;
        public string Path { get; private set; } = @"C:\Users\Mara\Pictures\CAMARA"; // Ruta predeterminada
        private bool hayDispositivos = false;
        private Timer timeContar; // Temporizador para la cuenta regresiva
        private int tiempoRestante = 3; // Tiempo de cuenta regresiva
        public event Action FotoTomada; // Evento para notificar que la foto fue tomada


    

        // Cargar dispositivos de cámara
        public void CargarDispositivos()
        {
            MisDispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            hayDispositivos = MisDispositivos.Count > 0;
        }

        // Obtener el número de dispositivos
        public int ObtenerNumeroDispositivos()
        {
            return MisDispositivos.Count;
        }

        // Obtener el nombre de un dispositivo
        public string ObtenerNombreDispositivo(int index)
        {
            return MisDispositivos[index].Name;
        }

        // Iniciar la cámara
        public void IniciarCamara(int indexDispositivo, PictureBox pictureBoxVideo)
        {
            CerrarWebCam(); // Cerrar si ya hay una cámara corriendo

            string nombreVideo = MisDispositivos[indexDispositivo].MonikerString;
            MiWebCam = new VideoCaptureDevice(nombreVideo);
            MiWebCam.NewFrame += (sender, e) => CapturandoFrame(sender, e, pictureBoxVideo); // Asignar método de captura de frames
            MiWebCam.Start();
        }

        // Detener la cámara
        public void CerrarWebCam()
        {
            if (MiWebCam != null && MiWebCam.IsRunning)
            {
                MiWebCam.SignalToStop();
                MiWebCam = null;
            }
        }

        // Método para capturar frames y mostrarlos en el PictureBox
        private void CapturandoFrame(object sender, NewFrameEventArgs eventArgs, PictureBox pictureBoxVideo)
        {
            Bitmap imagen = (Bitmap)eventArgs.Frame.Clone();
            pictureBoxVideo.Image = imagen; // Mostrar en el PictureBox
        }

        public void IniciarContador(Label labelContador, PictureBox pictureBoxVideo, PictureBox pictureBoxCapturada)
        {
            if (MiWebCam != null && MiWebCam.IsRunning)
            {
                labelContador.Text = "¡Preparate!";
                tiempoRestante = 3; // Reiniciar el contador a 3 segundos

                Timer preparateTimer = new Timer();
                preparateTimer.Interval = 2000; // Esperar 2 segundos
                preparateTimer.Tick += (s, ev) =>
                {
                    preparateTimer.Stop();
                    preparateTimer.Dispose();

                    labelContador.Text = tiempoRestante.ToString();
                    timeContar = new Timer(); // Inicializar el temporizador de cuenta regresiva
                    timeContar.Interval = 1000; // 1 segundo
                    timeContar.Tick += (s2, ev2) => {
                        if (tiempoRestante > 0)
                        {
                            labelContador.Text = tiempoRestante.ToString();
                            tiempoRestante--;
                        }
                        else
                        {
                            timeContar.Stop(); // Detener el temporizador
                            TomarFoto(pictureBoxVideo, pictureBoxCapturada); // Tomar la foto
                            FotoTomada?.Invoke(); // Notificar que la foto fue tomada
                            labelContador.Text = ""; // Limpiar el label (opcional)
                        }
                    };
                    timeContar.Start(); // Iniciar el temporizador
                };
                preparateTimer.Start(); // Iniciar el temporizador de preparación
            }
        }

        // Método para tomar la foto y mostrarla en otro PictureBox
        public void TomarFoto(PictureBox pictureBoxVideo, PictureBox pictureBoxCapturada)
        {
            if (MiWebCam != null && MiWebCam.IsRunning && pictureBoxVideo.Image != null)
            {
                pictureBoxCapturada.Image = (Bitmap)pictureBoxVideo.Image.Clone();

                // Asegurarse de que el usuario haya seleccionado una ruta
                if (string.IsNullOrEmpty(Path))
                {
                    MessageBox.Show("Por favor, seleccione una carpeta para guardar las fotos.");
                    return;
                }

                // Guardar la imagen capturada en la ruta seleccionada
                string nombreArchivo = System.IO.Path.Combine(Path, "captura_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".jpg");
                pictureBoxCapturada.Image.Save(nombreArchivo, ImageFormat.Jpeg);
                MessageBox.Show("Foto guardada en: " + nombreArchivo);
            }
        }

        // Seleccionar la ruta para guardar las fotos
        public string SeleccionarRutaFotos()
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

        public void EstablecerRuta(string nuevaRuta)
        {
            if (!string.IsNullOrEmpty(nuevaRuta))
            {
                Path = nuevaRuta;
            }
        }

    }
}