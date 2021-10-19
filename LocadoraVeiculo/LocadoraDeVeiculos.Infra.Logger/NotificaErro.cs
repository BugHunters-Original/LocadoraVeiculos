using LocadoraDeVeiculos.Infra.EmailLocadora;
using System;
using System.Net.Mail;

namespace LocadoraDeVeiculos.Infra.Logger
{
    public class NotificaErro
    {
        public static bool EnviarEmailErro(Exception ex)
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
                        email.To.Add(Email.EmailLocadoraSuporte);

                        email.Subject = "BeeCar";
                        email.IsBodyHtml = false;
                        email.Body = $"Ocorreu um erro. {ex}";

                        //ENVIAR
                        smtp.Send(email);
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
