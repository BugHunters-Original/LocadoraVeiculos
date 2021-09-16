using LocadoraDeVeiculos.Infra.JsonConfigGeral;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Infra.Combustivel
{
    public static class PrecoCombustivel
    {
        private static readonly Dictionary<string, string> camposIniciais = new Dictionary<string, string>()
            {
                {"precoGasolina", "0"},
                {"precoDiesel", "0" },
                {"precoAlcool", "0" },
            };

        private static JsonConfig appConfigControler;

        static PrecoCombustivel()
        {
            appConfigControler = new JsonConfig(camposIniciais);
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
                return Convert.ToDouble(appConfigControler.Ler("precoDiesel"));
            }
            set
            {
                appConfigControler.Setar("precoDiesel", value);
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
