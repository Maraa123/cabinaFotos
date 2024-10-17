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
            if (MiWebCam != null && MiWebCam.IsRunning) { 
            pictureBoxCapturada.Image = pictureBoxVideo.Image;
                pictureBoxCapturada.Image.Save(Path + "\\hdeleon.jpg", ImageFormat.Jpeg);
            }
        }
    }
}
