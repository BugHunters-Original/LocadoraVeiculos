using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace LocadoraDeVeiculos.Infra.JsonConfigGeral
{
    public class JsonConfig
    {
        public static string pathAppConfig = @$"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\appsettings.json";
        public static JObject AppConfig => JObject.Parse(File.ReadAllText(pathAppConfig));

        public JsonConfig(Dictionary<string, string> camposIniciais)
        {
            AdicionarCamposCasoNaoExistente(camposIniciais);
        }

        private void AdicionarCamposCasoNaoExistente(Dictionary<string, string> campos)
        {
            foreach (var campo in campos)
                if (AppConfig[campo.Key] == null)
                    Setar(campo.Key, campo.Value);
        }
        
        public string Ler(string chave)
        {
            return AppConfig[chave].ToString();
        }

        public void Setar(string chave, object valor)
        {
            var app = AppConfig;

            JValue jValue = new(valor);

            app[chave] = jValue;

            Save(app);
        }
        protected static void Save(JObject newAppConfig)
        {
            File.WriteAllText(pathAppConfig, JsonConvert.SerializeObject(newAppConfig));
        }

    }
}
