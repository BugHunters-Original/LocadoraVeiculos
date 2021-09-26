using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Infra.EmailLocadora;
using Serilog.Core;
using System.Net.Mail;

namespace LocadoraDeVeiculos.Infra.InternetServices
{
    public class EnviaEmail : IEmail
    {
        public bool EnviarEmail(Locacao locacao, Logger logger)
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


                        email.Attachments.Add(new Attachment($@"..\..\..\..\Recibos\recibo{locacao.Id}.pdf"));

                        //ENVIAR
                        smtp.Send(email);

                        logger.Debug($"E-Mail enviado para {locacao.Cliente.Email} com sucesso!");
                        
                        return true;
                    }
                }
            }
            catch
            {
                logger.Error($"Erro ao enviar E-Mail para {locacao.Cliente.Email}!");
                return false;
            }
        }
    }
}
