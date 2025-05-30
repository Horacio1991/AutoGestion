using AutoGestion.BE;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Windows.Forms;

namespace AutoGestion.Vista.Servicios
{
    public static class GeneradorFacturaPDF
    {
        public static void Generar(Factura factura)
        {
            using SaveFileDialog dialogo = new SaveFileDialog
            {
                Filter = "Archivo PDF (*.pdf)|*.pdf",
                FileName = $"Factura_{factura.ID}.pdf"
            };

            if (dialogo.ShowDialog() != DialogResult.OK)
                return;

            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(dialogo.FileName, FileMode.Create));
            doc.Open();

            // Corrección de conflicto de Font
            iTextSharp.text.Font titulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
            iTextSharp.text.Font normal = FontFactory.GetFont(FontFactory.HELVETICA, 12);

            // Título
            doc.Add(new iTextSharp.text.Paragraph("Factura Electrónica", titulo));
            doc.Add(new iTextSharp.text.Paragraph($"Fecha: {factura.Fecha.ToShortDateString()}", normal));
            doc.Add(new iTextSharp.text.Paragraph("\n"));

            // Datos del Cliente
            doc.Add(new iTextSharp.text.Paragraph("Datos del Cliente:", titulo));
            doc.Add(new iTextSharp.text.Paragraph($"{factura.Cliente.Nombre} {factura.Cliente.Apellido}", normal));
            doc.Add(new iTextSharp.text.Paragraph($"Contacto: {factura.Cliente.Contacto}", normal));
            doc.Add(new iTextSharp.text.Paragraph("\n"));

            // Datos del Vehículo
            doc.Add(new iTextSharp.text.Paragraph("Vehículo:", titulo));
            doc.Add(new iTextSharp.text.Paragraph($"{factura.Vehiculo.Marca} {factura.Vehiculo.Modelo}", normal));
            doc.Add(new iTextSharp.text.Paragraph($"Dominio: {factura.Vehiculo.Dominio}", normal));
            doc.Add(new iTextSharp.text.Paragraph("\n"));

            // Detalles de Facturación
            doc.Add(new iTextSharp.text.Paragraph("Detalles de Facturación:", titulo));
            doc.Add(new iTextSharp.text.Paragraph($"Forma de Pago: {factura.FormaPago}", normal));
            doc.Add(new iTextSharp.text.Paragraph($"Precio Total: ${factura.Precio}", normal));

            doc.Close();

            MessageBox.Show("Factura guardada correctamente en PDF.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
