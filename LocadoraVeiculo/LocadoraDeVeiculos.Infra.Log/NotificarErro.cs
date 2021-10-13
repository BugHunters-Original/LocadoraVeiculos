﻿using LocadoraDeVeiculos.Infra.EmailLocadora;
using LocadoraDeVeiculos.Infra.Shared;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.LogManager
{
    public class NotificarErro 
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
