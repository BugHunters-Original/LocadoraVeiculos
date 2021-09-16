using LocadoraDeVeiculos.Infra.JsonConfigGeral;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Infra.EmailLocadora
{
    public static class Email
    {
        private static readonly Dictionary<string, string> camposIniciais = new Dictionary<string, string>()
            {
                {"email", "email"},
                {"senha", "senha"}
            };

        private static JsonConfig appConfigControler;

        static Email()
        {
            appConfigControler = new JsonConfig(camposIniciais);
        }

        public static string EmailLocadora
        {
            get
            {
                return Convert.ToString(appConfigControler.Ler("email"));
            }
            set
            {
                appConfigControler.Setar("email", value);
            }
        }

        public static string SenhaLocadora
        {
            get
            {
                return Convert.ToString(appConfigControler.Ler("senha"));
            }
            set
            {
                appConfigControler.Setar("senha", value);
            }
        }

    }
}
