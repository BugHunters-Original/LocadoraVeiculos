using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Infra.EmailLocadora;
using Serilog.Core;
using System;
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

                        logger.Debug("E-MAIL ENVIADO PARA {EmailCliente} com sucesso!", locacao.Cliente.Email);

                        return true;
                    }
                }
            }
            catch(Exception ex)
            {                
                logger.Error("ERRO AO ENVIAR E-MAIL PARA {EmailCliente} | DATA: {DataEHora} | FEATURE: {Feature} | SQL: {Query}", locacao.Cliente.Email, DateTime.Now.ToString(), this.ToString(), ex.Message);
                return false;
            }
        }
    }
}
