using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Combustivel
{
    public static class Config
    {
        private static readonly Dictionary<string, string> camposIniciais = new Dictionary<string, string>()
            {
                {"precoGasolina", "0"},
                {"precoDieses", "0" },
                {"precoAlcool", "0" },
            };

        private static AppConfig appConfigControler;

        static Config()
        {
            appConfigControler = new AppConfig(camposIniciais);
        }

        public static double PrecoGasolina
        {
            get
            {
                return Convert.ToDouble(appConfigControler.Ler("precoGasolina"));
            }
            set
            {
                appConfigControler.Setar("precoGasolina", value);
            }
        }

        public static double PrecoDiesel
        {
            get
            {
                return Convert.ToDouble(appConfigControler.Ler("precoDieses"));
            }
            set
            {
                appConfigControler.Setar("precoDieses", value);
            }
        }

        public static double PrecoAlcool
        {
            get
            {
                return Convert.ToDouble(appConfigControler.Ler("precoAlcool"));
            }
            set
            {
                appConfigControler.Setar("precoAlcool", value);
            }
        }
    }
}
