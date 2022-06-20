using System.Collections.Generic;
using DashDigital.Domain.Notificacoes;

namespace DashDigital.Domain.Intefaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}