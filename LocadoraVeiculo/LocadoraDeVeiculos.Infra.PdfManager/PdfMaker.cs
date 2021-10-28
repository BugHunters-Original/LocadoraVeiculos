using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.ReciboModule;
using LocadoraDeVeiculos.Infra.ExtensionMethods;
using LocadoraDeVeiculos.Infra.Logger;
using System;
using System.IO;

namespace LocadoraDeVeiculos.Infra.PdfManager
{
    public class PdfMaker : IPDF
    {
        public Recibo MontarPDF(Locacao locacao)
        {
            try
            {
                var ms = new MemoryStream();
                var writer = new PdfWriter(ms);
                writer.SetCloseStream(false);
                var pdfDocument = new PdfDocument(writer);
                var pdf = new Document(pdfDocument);

                pdf.Add(new Paragraph("Recibo Locação de Automóvel\nBUG HUNTERS").SetTextAlignment(TextAlignment.CENTER).SetBold().SetFontSize(20));
                pdf.Add(new Paragraph("\n\n"));
                pdf.Add(new Paragraph("Cliente: " + locacao.Cliente.ToString()));
                pdf.Add(new Paragraph("Condutor: " + locacao.Condutor.ToString()));
                pdf.Add(new Paragraph("Veículo: " + locacao.Veiculo.Nome.ToString()));
                pdf.Add(new Paragraph("Data de Saída: " + locacao.DataSaida.ToString("d")));
                pdf.Add(new Paragraph("Data de Retorno: " + locacao.DataRetorno.ToString("d")));
                pdf.Add(new Paragraph("Plano Escolhido: " + locacao.LocacaoTipo));
                pdf.Add(new Paragraph("Total Plano Escolhido: R$" + locacao.PrecoPlano));

                if (locacao.TaxasDaLocacao != null)
                {
                    pdf.Add(new Paragraph("Serviço(s) Contratado(s): "));
                    foreach (var servico in locacao.TaxasDaLocacao)
                        pdf.Add(new Paragraph("--" + servico.ToString()));
                }
                else
                    pdf.Add(new Paragraph("Serviço(s) Contratado(s): Nenhum"));

                pdf.Add(new Paragraph("Total Servico(s) Escolhido(s): R$" + locacao.PrecoServicos));

                string cupomNome = locacao.Desconto?.Nome == null ? "Nenhum" : locacao.Desconto?.Nome;
                pdf.Add(new Paragraph("Cupom de Desconto: " + cupomNome));
                pdf.Add(new Paragraph("Veículo:"));
                var img = new Image(ImageDataFactory.Create(Images.logo.ToByteArray()));
                img.ScaleAbsolute(55, 55);
                img.SetFixedPosition(50f, 750f);
                pdf.Add(img);
                pdf.Add(new Image(ImageDataFactory.Create(locacao.Veiculo.Foto)));
                pdf.Add(new Paragraph("\n\n"));
                pdf.Add(new Paragraph($"Total: R${locacao.PrecoTotal}").SetBold().SetFontSize(30).SetTextAlignment(TextAlignment.CENTER));
                pdf.Close();

                Serilogger.Logger.Information("PDF DA LOCAÇÃO ID: {Id} CONCLUÍDO COM SUCESSO", locacao.Id);

                return new Recibo(locacao, ms);

            }
            catch (Exception ex)
            {
                Serilogger.Logger.Error(ex, "ERRO AO INSERIR LOCAÇÃO ID: {Id}", locacao.Id);
                return null;
            }
        }
    }
}
