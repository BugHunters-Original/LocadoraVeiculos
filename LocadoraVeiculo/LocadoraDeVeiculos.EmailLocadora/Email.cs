using LocadoraDeVeiculos.AppConfigGeral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.EmailLocadora
{
    public static class Email
    {
        private static readonly Dictionary<string, string> camposIniciais = new Dictionary<string, string>()
            {
                {"email", "email"},
                {"senha", "senha"}
            };

        private static AppConfig appConfigControler;

        static Email()
        {
            appConfigControler = new AppConfig(camposIniciais);
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
