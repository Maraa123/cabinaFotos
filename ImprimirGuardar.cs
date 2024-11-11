﻿using System;
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
        public void GuardarGroupBoxEnCarpeta(Control panel1)
        {
            // Verificar que la ruta esté establecida
            if (string.IsNullOrEmpty(Path))
            {
                MessageBox.Show("Por favor, seleccione una carpeta para guardar las fotos.");
                return;
            }

            // Capturar la imagen del GroupBox con todos los PictureBox cargados
            Bitmap groupBoxImagen = CapturarControl(panel1);

            if (groupBoxImagen != null)
            {
                // Generar un nombre de archivo único usando la fecha y la hora actuales
                string nombreArchivo = System.IO.Path.Combine(Path, "foto_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".jpg"
                );

                // Guardar la imagen en la carpeta seleccionada
                groupBoxImagen.Save(nombreArchivo, ImageFormat.Jpeg);
            }

        }

        public void ImprimirGroupBox(Control panel1)
        {
            Bitmap groupBoxImagen = CapturarControl(panel1, 2); // Factor de escala de 2 para alta resolución

            if (groupBoxImagen != null)
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintController = new StandardPrintController(); // Desactiva el diálogo de progreso
                pd.PrintPage += (sender, e) => ImprimirPagina(sender, e, groupBoxImagen);

                using (PrintDialog printDialog = new PrintDialog())
                {
                    printDialog.Document = pd;

                    if (printDialog.ShowDialog() == DialogResult.OK)
                    {
                        pd.Print();
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay contenido en el GroupBox para imprimir.");
            }
        }

        public void ImprimirDirectamente(Control panel1)
        {
            Bitmap groupBoxImagen = CapturarControl(panel1);

            if (groupBoxImagen != null)
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintController = new StandardPrintController(); // Suprime el diálogo de progreso
                pd.PrintPage += (sender, e) => ImprimirPagina(sender, e, groupBoxImagen);

                // Ejecuta la impresión sin mostrar diálogo
                pd.Print();
            }
            else
            {
                MessageBox.Show("No hay contenido en el GroupBox para imprimir.");
            }
        }

        private Bitmap CapturarControl(Control control, int scaleFactor = 1)
        {
            int width = control.Width * scaleFactor;
            int height = control.Height * scaleFactor;
            Bitmap bmp = new Bitmap(width, height);
            control.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
            return bmp;
        }

        private void ImprimirPagina(object sender, PrintPageEventArgs e, Bitmap imagenAImprimir)
        {
            e.PageSettings.Landscape = true;

            float a6WidthPoints = 5.83f * 96;  // A6 width in pixels at 96 DPI
            float a6HeightPoints = 4.13f * 96; // A6 height in pixels at 96 DPI
            RectangleF printArea = new RectangleF(0, 0, a6WidthPoints, a6HeightPoints);

            // Configura los gráficos para mejorar la calidad de impresión
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Dibuja la imagen en alta calidad
            e.Graphics.DrawImage(imagenAImprimir, printArea);
        }


    }
}

