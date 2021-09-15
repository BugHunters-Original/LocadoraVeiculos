﻿using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.EmailLocadora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.InternetServices
{
    public class EnviaEmail : IEmail
    {
        public bool EnviarEmail(Locacao locacao)
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