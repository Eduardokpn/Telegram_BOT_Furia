# 🐾 FuriaTec_TelegramBot

**FuriaTec_TelegramBot** é um bot interativo para o Telegram voltado aos fãs da FURIA Esports. Ele permite que os usuários:

- Treinem virtualmente com ídolos da FURIA
- Acompanhem os próximos jogos do time
- Ganhem certificados com imagem gerada dinamicamente
- Enviem seu e-mail para receber novidades exclusivas

---

## 📸 Funcionalidades

### ✅ Cadastro
- Ao iniciar o bot com `/start`, o usuário envia seu e-mail.
- Os dados são salvos em um banco em nuvem.

### 🧠 Treinador Virtual com IA
- O usuário escolhe um jogador como “treinador” (ex: FalleN, yuurih).
- O bot responde com mensagens motivacionais e técnicas usando IA (Maritaca).

### 🖼️ Certificado com Imagem Personalizada
- Após enviar o nome, o bot gera uma imagem personalizada com certificado.
- A imagem é criada via ImageSharp.

### 📅 Próximos Jogos da FURIA
- Integração com a API [PandaScore](https://developers.pandascore.co/) para exibir partidas futuras da FURIA.
- Mostra nome da partida, data e vencedor (se disponível).

---

## ⚙️ Tecnologias Utilizadas

- [.NET 7 + C#](https://dotnet.microsoft.com/)
- [Telegram.Bot SDK](https://github.com/TelegramBots/Telegram.Bot)
- [ImageSharp](https://github.com/SixLabors/ImageSharp)
- [SQLite](https://www.sqlite.org/)
- [PandaScore API](https://developers.pandascore.co/)
- [OpenRouter / Maritaca](https://openrouter.ai/) (para IA)

## 💬 Comandos Disponíveis

/start → Inicia a experiência, toca o áudio e solicita o e-mail

/menu → Mostra as opções para serem utlizadas no bot

/treinar → Escolhe um jogador para treinar com você via IA

/jogos → Mostra os próximos jogos da FURIA em 2025

## 👨‍💻 Como Rodar Localmente

git clone https://github.com/seu-usuario/FuriaTec_TelegramBot.git
cd FuriaTec_TelegramBot
dotnet build
dotnet run



