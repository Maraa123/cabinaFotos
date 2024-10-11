using AForge.Video.DirectShow;
using AForge.Video;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cabinaFotos
{
    class Camara
    {
        // Eventos para manejar nuevos cuadros y errores
        public event NewFrameEventHandler OnNewFrame;
        public event EventHandler OnError;

        private FilterInfoCollection dispositivosVideo;
        private VideoCaptureDevice fuenteVideo;

        public Camara()
        {
            EnumerarCamaras();
        }

        /// <summary>
        /// Obtiene la lista de nombres de las cámaras disponibles.
        /// </summary>
        /// <returns>Array de nombres de cámaras.</returns>
        public string[] ObtenerCamarasDisponibles()
        {
            string[] nombres = new string[dispositivosVideo.Count];
            for (int i = 0; i < dispositivosVideo.Count; i++)
            {
                nombres[i] = dispositivosVideo[i].Name;
            }
            return nombres;
        }

        /// <summary>
        /// Inicia la cámara seleccionada por su índice en la lista.
        /// </summary>
        /// <param name="indice">Índice de la cámara en la lista de dispositivos.</param>
        public void IniciarCamara(int indice)
        {
            if (indice < 0 || indice >= dispositivosVideo.Count)
                throw new ArgumentOutOfRangeException("Índice de cámara no válido.");

            // Detener cualquier fuente de video previa
            DetenerCamara();

            fuenteVideo = new VideoCaptureDevice(dispositivosVideo[indice].MonikerString);
            fuenteVideo.NewFrame += FuenteVideo_NewFrame;
            fuenteVideo.VideoSourceError += FuenteVideo_VideoSourceError;
            fuenteVideo.Start();
        }

        /// <summary>
        /// Detiene la transmisión de la cámara si está en ejecución.
        /// </summary>
        public void DetenerCamara()
        {
            if (fuenteVideo != null && fuenteVideo.IsRunning)
            {
                fuenteVideo.SignalToStop();
                fuenteVideo.WaitForStop();
                fuenteVideo.NewFrame -= FuenteVideo_NewFrame;
                fuenteVideo.VideoSourceError -= FuenteVideo_VideoSourceError;
                fuenteVideo = null;
            }
        }

        /// <summary>
        /// Evento manejador para nuevos cuadros de video.
        /// </summary>
        private void FuenteVideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            OnNewFrame?.Invoke(this, eventArgs);
        }

        /// <summary>
        /// Evento manejador para errores en la fuente de video.
        /// </summary>
        private void FuenteVideo_VideoSourceError(object sender, VideoSourceErrorEventArgs eventArgs)
        {
            OnError?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Método privado para enumerar las cámaras disponibles.
        /// </summary>
        private void EnumerarCamaras()
        {
            dispositivosVideo = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        }

        /// <summary>
        /// Libera recursos al destruir la instancia.
        /// </summary>
        ~Camara()
        {
            DetenerCamara();
        }
    }
}



