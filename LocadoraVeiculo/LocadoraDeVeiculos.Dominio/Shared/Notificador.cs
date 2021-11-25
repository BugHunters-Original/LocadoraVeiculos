using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Shared
{

    public class Notificador : INotificador
    {
        private List<string> _notificacoes;

        public Notificador()
        {
            _notificacoes = new List<string>();
        }

        public void RegistrarNotificacao(string notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public List<string> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public bool TemNotificacao()
        {
            return _notificacoes.Any();
        }
    }

}
