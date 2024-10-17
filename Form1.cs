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

namespace cabinaFotos
{
    public partial class Form1 : Form {

        public string Path = @"C:\Users\Mara\Pictures\CAMARA";
        private bool hayDispositivos;
        private FilterInfoCollection MisDispositivos;
        private VideoCaptureDevice MiWebCam;
        private Timer TimeContar;
        private int tiempoRestante = 3; // 3 segundos para el contador


        FormuCamara ventanaCamara;
        public Form1() {
            InitializeComponent();
            ventanaCamara = new FormuCamara();
            // Inicializar el Timer
            TimeContar = new Timer();
            TimeContar.Interval = 1000; // 1000 milisegundos = 1 segundo
            TimeContar.Tick += new EventHandler(timeContar_Tick); // Asignar evento

        }

        public void CargaDispositivos() {
            MisDispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (MisDispositivos.Count > 0) {
                hayDispositivos = true;
                for(int i = 0; i < MisDispositivos.Count; i++)
                    comboBoxCamaras.Items.Add(MisDispositivos[i].Name.ToString());
                comboBoxCamaras.Text = MisDispositivos[0].Name.ToString();
            }
            else  
                hayDispositivos=false;
            
        }

        private void Form1_Load(object sender, EventArgs e) {
            CargaDispositivos();
        }

        private void CerrarWebCam() {

            if (MiWebCam != null && MiWebCam.IsRunning) { 
            
                MiWebCam.SignalToStop();
                MiWebCam = null;
            
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e) {
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

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            CerrarWebCam();
        }

        private void btnTomarFoto_Click(object sender, EventArgs e) {
            if (MiWebCam != null && MiWebCam.IsRunning) {
                label1Contar.Text = "¡Preparate!";
                tiempoRestante = 3; // Reiniciar el contador a 3 segundos

                // Usar un temporizador para esperar 2 segundos antes de iniciar el contador
                Timer preparateTimer = new Timer();
                preparateTimer.Interval = 2000; // Esperar 2 segundos
                preparateTimer.Tick += (s, ev) => {
                    preparateTimer.Stop(); // Detener el temporizador de preparación
                    preparateTimer.Dispose(); // Limpiar el recurso

                    label1Contar.Text = tiempoRestante.ToString(); // Mostrar el contador
                    TimeContar.Start(); // Iniciar el temporizador de fotos
                };
                preparateTimer.Start(); // Iniciar el temporizador de preparación

            }
        }
        private void TomarFoto() {
            if (MiWebCam != null && MiWebCam.IsRunning) {
                pictureBoxCapturada.Image = pictureBoxVideo.Image;

                // Asegurarse de que el usuario haya seleccionado una ruta
                if (string.IsNullOrEmpty(Path))  {
                    MessageBox.Show("Por favor, seleccione una carpeta para guardar las fotos.");
                    return;
                }

                // Usar la ruta seleccionada y generar un nombre único para el archivo
                string nombreArchivo = System.IO.Path.Combine(Path, "captura_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".jpg");

                pictureBoxCapturada.Image.Save(nombreArchivo, ImageFormat.Jpeg);
               // MessageBox.Show("Foto guardada en: " + nombreArchivo);

            }
        }

        private string SeleccionarRutaFotos(){
            using (FolderBrowserDialog dialog = new FolderBrowserDialog()) {
                dialog.Description = "Seleccione la carpeta donde desea guardar las fotos";

                if (dialog.ShowDialog() == DialogResult.OK) {
                    return dialog.SelectedPath; // Devolver la ruta seleccionada
                }
                else{
                    return null; // Si no se selecciona una carpeta
                }
            }
        }

        private void btnCarpeta_Click(object sender, EventArgs e) {
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

        private void timeContar_Tick(object sender, EventArgs e) {
            if (tiempoRestante > 0){
                // Mostrar el contador en el formulario (opcional)
                label1Contar.Text = tiempoRestante.ToString(); // Suponiendo que tienes un label llamado lblContador
                tiempoRestante--;
            }
            else{
                // Detener el temporizador cuando llega a 0
                TimeContar.Stop();
                label1Contar.Text = ""; // Limpiar el contador (opcional)

                // Tomar la foto
                TomarFoto();
            }
        }

        public void ImprimirImagen()
        {
            if (pictureBoxCapturada.Image != null)
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(ImprimirPagina);
                PrintDialog printDialog = new PrintDialog();

                // Asignar el documento de impresión
                printDialog.Document = pd;

                // Mostrar el cuadro de diálogo de impresión
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    pd.Print(); // Imprimir la imagen
                }
            }
            else
            {
                MessageBox.Show("No hay imagen capturada para imprimir.");
            }
        }

        private void ImprimirPagina(object sender, PrintPageEventArgs e)
        {
            if (pictureBoxCapturada.Image != null)
            {
                // Obtener la imagen a imprimir
                Image imagenAImprimir = pictureBoxCapturada.Image;

                // Dibujar la imagen en la página de impresión
                e.Graphics.DrawImage(imagenAImprimir, new Point(0, 0));
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ImprimirImagen();
        }

       
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            ventanaCamara.ShowDialog();



        }
    }
}
