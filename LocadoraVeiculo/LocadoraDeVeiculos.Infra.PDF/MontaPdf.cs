using iText.IO.Image;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Infra.ExtensionMethods;
using LocadoraDeVeiculos.Infra.Logger;
using System;

namespace LocadoraDeVeiculos.Infra.PDFLocacao
{
    public class MontaPdf : IPDF
    {
        public bool MontarPDF(Locacao locacao)
        {
            try
            {
                using (PdfWriter wPdf = new PdfWriter($@"..\..\..\..\Recibos\recibo{locacao.Id}.pdf", new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
                {
                    var pdfDocument = new PdfDocument(wPdf);
                    var document = new Document(pdfDocument, PageSize.A4);
                    document.Add(new Paragraph("Recibo Locação de Automóvel\nBUG HUNTERS").SetTextAlignment(TextAlignment.CENTER).SetBold().SetFontSize(20));
                    document.Add(new Paragraph("\n\n"));
                    document.Add(new Paragraph("Cliente: " + locacao.Cliente.ToString()));
                    document.Add(new Paragraph("Condutor: " + locacao.Condutor.ToString()));
                    document.Add(new Paragraph("Veículo: " + locacao.Veiculo.Nome.ToString()));
                    document.Add(new Paragraph("Data de Saída: " + locacao.DataSaida.ToString("d")));
                    document.Add(new Paragraph("Data de Retorno: " + locacao.DataRetorno.ToString("d")));
                    document.Add(new Paragraph("Plano Escolhido: " + locacao.TipoLocacao));
                    document.Add(new Paragraph("Total Plano Escolhido: R$" + locacao.PrecoPlano));

                    if (locacao.TaxasDaLocacao != null)
                    {
                        document.Add(new Paragraph("Serviço(s) Contratado(s): "));
                        foreach (var servico in locacao.TaxasDaLocacao)
                            document.Add(new Paragraph("--" + servico.ToString()));
                    }
                    else
                        document.Add(new Paragraph("Serviço(s) Contratado(s): Nenhum"));

                    document.Add(new Paragraph("Total Servico(s) Escolhido(s): R$" + locacao.PrecoServicos));

                    string cupomNome = locacao.Desconto?.Nome == null ? "Nenhum" : locacao.Desconto?.Nome;
                    document.Add(new Paragraph("Cupom de Desconto: " + cupomNome));
                    document.Add(new Paragraph("Veículo:"));
                    var img = new Image(ImageDataFactory.Create(@"..\..\..\..\Logo\logo.png"));
                    img.ScaleAbsolute(55, 55);
                    img.SetFixedPosition(50f, 750f);
                    document.Add(img);
                    document.Add(new Image(ImageDataFactory.Create(locacao.Veiculo.Foto)));
                    document.Add(new Paragraph("\n\n"));
                    document.Add(new Paragraph($"Total: R${locacao.PrecoTotal}").SetBold().SetFontSize(30).SetTextAlignment(TextAlignment.CENTER));
                    document.Close();

                    pdfDocument.Close();

                    Serilogger.Logger.Aqui().Information("PDF DA LOCAÇÃO ID: {Id} CONCLUÍDO COM SUCESSO", locacao.Id);

                    return true;
                }
            }
            catch (Exception ex)
            {
                Serilogger.Logger.Aqui().Error(ex, "ERRO AO INSERIR LOCAÇÃO ID: {Id}", locacao.Id);
                return false;
            }
        }
    }
}
