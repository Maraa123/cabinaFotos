using AForge.Video;
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

namespace cabinaFotos
{
    public partial class FormuCamara : Form
    {
        private Camara camara;
        public Action<Bitmap> ImagenCapturadaCallback; // Delegado para enviar la imagen capturada

       
    }
}
