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
            private int tiempoRestante = 5; // Tiempo de cuenta regresiva
            private int contadorFotos = 0;
            private Timer temporizadorCaptura;

            public event Action CapturaFinalizada;

            public void CargarDispositivos()
            {
                MisDispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                hayDispositivos = MisDispositivos.Count > 0;
            }

            public int ObtenerNumeroDispositivos() => MisDispositivos.Count;

            public string ObtenerNombreDispositivo(int index) => MisDispositivos[index].Name;

            public void IniciarCamara(int indexDispositivo, PictureBox pictureBoxVideo)
            {
                CerrarWebCam();
                string nombreVideo = MisDispositivos[indexDispositivo].MonikerString;
                MiWebCam = new VideoCaptureDevice(nombreVideo);
                MiWebCam.NewFrame += (sender, e) => CapturandoFrame(sender, e, pictureBoxVideo);
                MiWebCam.Start();
            }

            public void CerrarWebCam()
            {
                if (MiWebCam != null && MiWebCam.IsRunning)
                {
                    MiWebCam.SignalToStop();
                    MiWebCam = null;
                }
            }

            private void CapturandoFrame(object sender, NewFrameEventArgs eventArgs, PictureBox pictureBoxVideo)
            {
                pictureBoxVideo.Image = (Bitmap)eventArgs.Frame.Clone();
            }

            public void IniciarCapturaConCuentaRegresiva(Label labelContador, PictureBox pictureBoxVideo, PictureBox[] pictureBoxes)
            {
                if (MiWebCam == null || !MiWebCam.IsRunning)
                    return;

                labelContador.Text = "¡Prepárate!";
                contadorFotos = 0;
                tiempoRestante = 5;

                temporizadorCaptura = new Timer
                {
                    Interval = 1000
                };
                temporizadorCaptura.Tick += (s, ev) => GestionarCuentaRegresiva(labelContador, pictureBoxVideo, pictureBoxes);
                temporizadorCaptura.Start();
            }

            private void GestionarCuentaRegresiva(Label labelContador, PictureBox pictureBoxVideo, PictureBox[] pictureBoxes)
            {
                if (tiempoRestante > 0)
                {
                    labelContador.Text = tiempoRestante.ToString();
                    tiempoRestante--;
                }
                else
                {
                    // Tomar foto y guardar si es posible
                    TomarYGuardarFoto(pictureBoxVideo, pictureBoxes[contadorFotos]);

                    contadorFotos++;
                    if (contadorFotos < pictureBoxes.Length)
                    {
                        tiempoRestante = 5; // Reiniciar el contador para la próxima foto
                    }
                    else
                    {
                        temporizadorCaptura.Stop();
                        temporizadorCaptura.Dispose();
                        labelContador.Text = ""; // Limpiar el label
                        CapturaFinalizada?.Invoke();

                         }
                }
            }

            private void TomarYGuardarFoto(PictureBox pictureBoxVideo, PictureBox pictureBoxCapturada)
            {
                if (MiWebCam != null && MiWebCam.IsRunning && pictureBoxVideo.Image != null)
                {
                    pictureBoxCapturada.Image = (Bitmap)pictureBoxVideo.Image.Clone();

                    // Asegurarse de que la ruta esté establecida
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
