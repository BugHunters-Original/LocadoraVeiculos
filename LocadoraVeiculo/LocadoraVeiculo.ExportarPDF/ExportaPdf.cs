using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using LocadoraVeiculo.LocacaoModule;

namespace LocadoraVeiculo.ExportacaoPDF
{
    public static class ExportaPdf
    {
        public static void ExportarLocacaoEmPDF(LocacaoVeiculo locacao)
        {
            using (PdfWriter wPdf = new PdfWriter($@"..\..\..\Recibos\recibo{locacao.Id}.pdf", new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
            {
                var pdfDocument = new PdfDocument(wPdf);

                var document = new Document(pdfDocument, PageSize.A4);
                document.Add(new Paragraph("Recibo Locação de Automóvel").SetTextAlignment(TextAlignment.CENTER).SetBold().SetFontSize(20));
                document.Add(new Paragraph("\n\n"));
                document.Add(new Paragraph("Cliente: " + locacao.Cliente.ToString()));
                document.Add(new Paragraph("Condutor: " + locacao.Condutor.ToString()));
                document.Add(new Paragraph("Veículo: " + locacao.Veiculo.nome.ToString()));
                document.Add(new Paragraph("Data de Saída: " + locacao.DataSaida.ToString("d")));
                document.Add(new Paragraph("Data de Retorno: " + locacao.DataRetorno.ToString("d")));
                document.Add(new Paragraph("Plano Escolhido: " + locacao.TipoLocacao));
                document.Add(new Paragraph("Total Plano Escolhido: R$" + locacao.PrecoPlano));

                if (locacao.Servicos != null)
                {
                    document.Add(new Paragraph("Serviço(s) Contratado(s): "));
                    foreach (var servico in locacao.Servicos)
                        document.Add(new Paragraph("--" + servico.ToString()));
                }
                else
                    document.Add(new Paragraph("Serviço(s) Contratado(s): Nenhum"));

                document.Add(new Paragraph("Total Servico(s) Escolhido(s): R$" + locacao.PrecoServicos));

                string cupomNome = locacao.Desconto?.Nome == null ? "Nenhum" : locacao.Desconto?.Nome;
                document.Add(new Paragraph("Cupom de Desconto: " + cupomNome));

                document.Add(new Paragraph("\n\n"));
                document.Add(new Paragraph("Total da Locação: R$" + locacao.PrecoTotal).SetBold());

                document.Close();

                pdfDocument.Close();
            }
        }
    }
}
