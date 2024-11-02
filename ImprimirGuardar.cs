using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace cabinaFotos
{
    public class ImprimirGuardar
    {

        public string Path { get; private set; } = @"C:\Users\Mara\Pictures\CAMARA"; // Ruta predeterminada

      
        public string SeleccionarRutaFotos()
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Seleccione la carpeta donde desea guardar las fotos";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.SelectedPath; 
                }
                else
                {
                    return null;
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

        // Método para guardar el GroupBox con los PictureBox cargados
        public void GuardarGroupBoxEnCarpeta(Control groupBox)
        {
            // Verificar que la ruta esté establecida
            if (string.IsNullOrEmpty(Path))
            {
                MessageBox.Show("Por favor, seleccione una carpeta para guardar las fotos.");
                return;
            }

            // Capturar la imagen del GroupBox con todos los PictureBox cargados
            Bitmap groupBoxImagen = CapturarControl(groupBox);

            if (groupBoxImagen != null)
            {
                // Generar un nombre de archivo único usando la fecha y la hora actuales
                string nombreArchivo = System.IO.Path.Combine(Path,"foto_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".jpg"
                );

                // Guardar la imagen en la carpeta seleccionada
                groupBoxImagen.Save(nombreArchivo, ImageFormat.Jpeg);
            }
          
        }


        public void ImprimirGroupBox(Control groupBox)
        {

            Bitmap groupBoxImagen = CapturarControl(groupBox);

            if (groupBoxImagen != null)
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += (sender, e) => ImprimirPagina(sender, e, groupBoxImagen);
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = pd;

            }
            else
            {
                MessageBox.Show("No hay contenido en el GroupBox para imprimir.");
            }
        }

        private Bitmap CapturarControl(Control control)
        {
            Bitmap bmp = new Bitmap(control.Width, control.Height);
            control.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            return bmp;
        }

        private void ImprimirPagina(object sender, PrintPageEventArgs e, Bitmap imagenAImprimir)
        {
            e.PageSettings.Landscape = true;

            // Definir tamaño A6 en puntos (96 puntos por pulgada)
            float a6WidthPoints = 5.83f * 96;
            float a6HeightPoints = 4.13f * 96;

            // Escalar la imagen del GroupBox al tamaño A6
            RectangleF printArea = new RectangleF(0, 0, a6WidthPoints, a6HeightPoints);

            e.Graphics.DrawImage(imagenAImprimir, printArea);
        }
    }


}

