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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

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
            CerrarWebCam();

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
            pictureBoxVideo.Image = imagen; 
        }


        private int contadorFotos = 0;

        public void IniciarContador(Label labelContador, PictureBox pictureBoxVideo, PictureBox[] pictureBoxes)
        {
            if (MiWebCam != null && MiWebCam.IsRunning)
            {
                labelContador.Text = "¡Prepárate!";
                tiempoRestante = 3; // Reiniciar el contador a 3 segundos

                Timer preparateTimer = new Timer();
                preparateTimer.Interval = 1000; // 1 segundo
                preparateTimer.Tick += (s, ev) =>
                {
                    if (tiempoRestante > 0)
                    {
                        labelContador.Text = tiempoRestante.ToString();
                        tiempoRestante--;
                    }
                    else
                    {
                        preparateTimer.Stop();
                        preparateTimer.Dispose();

                        // Tomar la primera foto
                        TomarFoto(pictureBoxVideo, pictureBoxes[contadorFotos]);
                        contadorFotos++;

                        // Comenzar el temporizador para las siguientes fotos
                        IniciarCapturaDeFotos(labelContador, pictureBoxVideo, pictureBoxes);
                    }
                };
                preparateTimer.Start(); // Iniciar el temporizador de preparación
            }
        }

        private void IniciarCapturaDeFotos(Label labelContador, PictureBox pictureBoxVideo, PictureBox[] pictureBoxes)
        {
            if (contadorFotos < pictureBoxes.Length) // Solo tomar fotos según el número de PictureBox
            {
                tiempoRestante = 3; // Reiniciar el contador a 3 segundos
                Timer tiempoFoto = new Timer();
                tiempoFoto.Interval = 1000; // 1 segundo
                tiempoFoto.Tick += (s, ev) =>
                {
                    if (tiempoRestante > 0)
                    {
                        labelContador.Text = tiempoRestante.ToString();
                        tiempoRestante--;
                    }
                    else
                    {
                        tiempoFoto.Stop();
                        tiempoFoto.Dispose();

                        // Tomar la foto
                        TomarFoto(pictureBoxVideo, pictureBoxes[contadorFotos]);
                        contadorFotos++;

                        // Continuar si aún hay más fotos por tomar
                        IniciarCapturaDeFotos(labelContador, pictureBoxVideo, pictureBoxes);
                    }
                };
                tiempoFoto.Start(); // Iniciar el temporizador para las fotos
            }
            else
            {
                labelContador.Text = ""; // Limpiar el label al finalizar
                contadorFotos = 0; // Reiniciar el contador de fotos
            }
        }

        // Método para tomar la foto y mostrarla en el PictureBox especificado
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

            }
        }

    }
}