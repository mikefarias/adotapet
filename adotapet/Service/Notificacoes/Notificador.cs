using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Notificacoes
{
    class Notificador : INotificador
    {
        private List<Notificacao> _notificacoes;

        public void Handle(Notificacao notificacao) => _notificacoes = new List<Notificacao>();

        public List<Notificacao> ObterNotificacoes() => _notificacoes;

        public bool TemNotificacao() => _notificacoes.Any();
    }
}
