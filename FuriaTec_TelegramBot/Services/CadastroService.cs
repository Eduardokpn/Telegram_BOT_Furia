using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuriaTec_TelegramBot.Services
{
    public class CadastroService
    {
        private readonly HashSet<long> aguardandoEmail = new();

        public bool EstaAguardandoEmail(long telegramId)
            => aguardandoEmail.Contains(telegramId);

        public void MarcarComoAguardando(long telegramId)
            => aguardandoEmail.Add(telegramId);

        public void RemoverAguardando(long telegramId)
            => aguardandoEmail.Remove(telegramId);
    }

}
