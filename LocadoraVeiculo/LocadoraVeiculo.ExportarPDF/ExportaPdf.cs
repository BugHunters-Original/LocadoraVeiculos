using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using LocadoraVeiculo.EmailLocadora;
using LocadoraVeiculo.LocacaoModule;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                document.Add(new Paragraph("Recibo Locação de Automóvel\nBUG HUNTERS").SetTextAlignment(TextAlignment.CENTER).SetBold().SetFontSize(20));
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
                document.Add(new Paragraph("Veículo:"));
                document.Add(new Image(ImageDataFactory.Create(locacao.Veiculo.foto)));
                document.Add(new Paragraph("\n\n"));
                document.Add(new Paragraph("Total da Locação: R$" + locacao.PrecoTotal).SetBold());

                document.Close();

                pdfDocument.Close();
            }

            Task.Run(() => EmailEnviar(locacao));
        }
        public static void EmailEnviar(LocacaoVeiculo locacao)
        {
            try
            {
                using (SmtpClient smtp = new SmtpClient())
                {
                    using (MailMessage email = new MailMessage())
                    {
                        //SERVIDOR
                        smtp.Host = "smtp.gmail.com";
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new System.Net.NetworkCredential(Email.EmailLocadora, Email.SenhaLocadora);
                        smtp.Port = 587;
                        smtp.EnableSsl = true;

                        //EMAIL
                        email.From = new MailAddress(Email.EmailLocadora);
                        email.To.Add(locacao.Cliente.Email);

                        email.Subject = "BeeCar";
                        email.IsBodyHtml = false;
                        email.Body = "Obrigado por utilizar nossos serviços, volte sempre!";


                        email.Attachments.Add(new Attachment($@"..\..\..\Recibos\recibo{locacao.Id}.pdf"));

                        //ENVIAR
                        smtp.Send(email);

                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }

        }
    }
}
