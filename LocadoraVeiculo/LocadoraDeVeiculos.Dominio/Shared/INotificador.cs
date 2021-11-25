using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.Shared
{
    public interface INotificador
    {
        List<string> ObterNotificacoes();
        void RegistrarNotificacao(string notificacao);
        bool TemNotificacao();
    }
}