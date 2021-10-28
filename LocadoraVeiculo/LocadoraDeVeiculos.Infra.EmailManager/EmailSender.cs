using LocadoraDeVeiculos.Dominio.ReciboModule;
using LocadoraDeVeiculos.Infra.EmailLocadora;
using LocadoraDeVeiculos.Infra.Logger;
using System;
using System.Net.Mail;

namespace LocadoraDeVeiculos.Infra.EmailManager
{
    public static class EmailSender
    {
        public static bool EnviarEmail(Recibo recibo)
        {
            try
            {
                using (SmtpClient smtp = new SmtpClient())
                {
                    using (MailMessage email = new MailMessage())
                    {
                        smtp.Host = "smtp.gmail.com";
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new System.Net.NetworkCredential(Email.EmailLocadora, Email.SenhaLocadora);
                        smtp.Port = 587;
                        smtp.EnableSsl = true;

                        email.From = new MailAddress(Email.EmailLocadora);
                        email.To.Add(recibo.Locacao.Cliente.Email);

                        email.Subject = "BeeCar";
                        email.IsBodyHtml = false;
                        email.Body = "Obrigado por utilizar nossos serviços, volte sempre!";

                        email.Attachments.Add(new Attachment(recibo.Pdf, "ReciboAluguel.pdf"));

                        smtp.Send(email);

                        Serilogger.Logger.Debug("E-MAIL ENVIADO PARA {EmailCliente} com sucesso!", recibo.Locacao.Cliente.Email);

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Serilogger.Logger.Error(ex, "ERRO AO ENVIAR E-MAIL PARA {EmailCliente} ");
                return false;
            }
        }
    }
}
