using AutoGestion.BE;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Windows.Forms;

namespace AutoGestion.Vista.Servicios
{
    public static class GeneradorComprobantePDF
    {
        public static void Generar(Venta venta)
        {
            using SaveFileDialog dialogo = new SaveFileDialog
            {
                Filter = "Archivo PDF (*.pdf)|*.pdf",
                FileName = $"Comprobante_Entrega_{venta.ID}.pdf"
            };

            if (dialogo.ShowDialog() != DialogResult.OK)
                return;

            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(dialogo.FileName, FileMode.Create));
            doc.Open();

            var titulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
            var normal = FontFactory.GetFont(FontFactory.HELVETICA, 12);

            doc.Add(new Paragraph("Comprobante de Entrega", titulo));
            doc.Add(new Paragraph($"Fecha: {DateTime.Now.ToShortDateString()}", normal));
            doc.Add(new Paragraph("\n"));

            doc.Add(new Paragraph("Cliente:", titulo));
            doc.Add(new Paragraph($"{venta.Cliente.Nombre} {venta.Cliente.Apellido}", normal));
            doc.Add(new Paragraph($"Contacto: {venta.Cliente.Contacto}", normal));
            doc.Add(new Paragraph("\n"));

            doc.Add(new Paragraph("Vehículo:", titulo));
            doc.Add(new Paragraph($"{venta.Vehiculo.Marca} {venta.Vehiculo.Modelo}", normal));
            doc.Add(new Paragraph($"Dominio: {venta.Vehiculo.Dominio}", normal));
            doc.Add(new Paragraph("\n"));

            doc.Add(new Paragraph("Pago:", titulo));
            doc.Add(new Paragraph($"Tipo de Pago: {venta.Pago.TipoPago}", normal));
            doc.Add(new Paragraph($"Monto: ${venta.Pago.Monto}", normal));

            doc.Close();

            MessageBox.Show("PDF guardado correctamente.");
        }
    }
}
