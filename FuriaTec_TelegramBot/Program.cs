
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;
using FuriaTec_TelegramBot.Services;
using Microsoft.Extensions.DependencyInjection;
using FuriaTec_TelegramBot.Data;
using RestSharp;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using EsportsModels;


var serviceProvider = new ServiceCollection()
            .AddSingleton<ChatService>()
            .AddSingleton<ImagemService>()
            .AddSingleton<UsuariosDB>() 
            .AddSingleton<CadastroService>()
            .BuildServiceProvider();

var chatService = serviceProvider.GetService<ChatService>();
var imagemService = serviceProvider.GetService<ImagemService>();
var usuariosDB = serviceProvider.GetService<UsuariosDB>();
var cadastroService = serviceProvider.GetService<CadastroService>();


using var cts = new CancellationTokenSource();
var bot = new TelegramBotClient("7915637811:AAEZWBusA9YKlHpj1oaDYSWMcrn9p2IA-hw", cancellationToken: cts.Token);
var me = await bot.GetMe();


bot.OnError += OnError;
bot.OnMessage += OnMessage;
bot.OnUpdate += OnUpdate;

Console.WriteLine($"@{me.Username} is running... Press Enter to terminate");
Console.ReadLine();
cts.Cancel();

async Task OnError(Exception exception, HandleErrorSource source)
{
    Console.WriteLine(exception); // just dump the exception to the console
}

async Task OnMessage(Message msg, UpdateType type)
{
    var telegramId = msg.From.Id;
    var nome = msg.From.FirstName;
    var texto = msg.Text;

    if (!usuariosDB.UsuarioExiste(telegramId))
    {
        if(cadastroService.EstaAguardandoEmail(telegramId))
        {

            usuariosDB.AdicionarUsuario(telegramId, nome, texto);
            cadastroService.RemoverAguardando(telegramId);
            await bot.SendMessage(msg.Chat.Id, "✅ Obrigado! Agora você faz parte da Nação FURIA!. Agora é so dar um /start e ir mais fundo na nossa equipe 🔥");
        
        }
        else
        {
            
            cadastroService.MarcarComoAguardando(telegramId);
            await bot.SendMessage(msg.Chat.Id, "🔥 Que bom que você chegou! Temos muito mais esperando por você. Montamos tudo com muito carinho para te deixar por dentro de tudo da Nação FURIA. 😎 Mas antes de começarmos, para você ficar por dentro de todas as novidades e ser um fã real da FURIA, manda seu e-mail aí para a gente! 📧\"");

            return;
        }

    }

    if (!usuariosDB.UsuarioExiste(telegramId)) // Primeira vez
    {
        // Toca o áudio de boas-vindas
        var buffer = File.ReadAllBytes("C:/Users/eduar/OneDrive/Documentos/Projetos/FuriaTec_TelegramBot/FuriaTec_TelegramBot/Resources/audio-fallen-furia.mp3");
        await using var ms = new MemoryStream(buffer);
        var message = await bot.SendAudio(msg.Chat, InputFile.FromStream(ms, "Bem Vindo.mp3"));
        await bot.SendMessage(msg.Chat, "🐾 Fala, fã da FURIA!\r\nA FURIA é mais que um time — é uma nação movida por garra, paixão e atitude! 💥\r\nCada vitória, cada desafio, tudo é vivido junto com você, que faz parte dessa família insana. 💜\r\nManda aqui seu nome e receba um presente feito com todo o respeito e amor que a FURIA tem pelos seus fãs. 🎁🔥\r\nBora mostrar que #SerFURIA é viver intensamente!"); 

        var nomeCertificado = msg.Text;

        // Gera e envia imagem
        var caminhoImagem = await imagemService.GerarImagem(nomeCertificado);
        var bufferImage = File.ReadAllBytes(caminhoImagem);
        await using var msImg = new MemoryStream(bufferImage);
        await bot.SendPhoto(msg.Chat.Id, InputFile.FromStream(msImg, "Certificado.png"));
    }
    else
    {
  
        await bot.SendMessage(msg.Chat.Id, "🐾 Eai, precisando de ajuda ?, é só dar um\n/menu 🚀 ");
    }

    switch (msg.Text)
    {
        case "/treinar":

            await bot.SendMessage(msg.Chat, "Você está prestes a treinar com os melhores da FURIA! 💪 \n Escolha seu treinador e prepare-se para evoluir no CS2. E se tiver dúvidas, é só perguntar estamos aqui pra te ajudar a dar o próximo passo! 🚀");
            
            await bot.SendMessage(msg.Chat, "Escolha seu treinador:", replyMarkup: new InlineKeyboardMarkup(new[] {
                new [] {
                    InlineKeyboardButton.WithCallbackData("FalleN", "fallen"),
                    InlineKeyboardButton.WithCallbackData("Yuurih", "yuurih"),
                    InlineKeyboardButton.WithCallbackData("KSCERATO", "KSCERATO"),
                    InlineKeyboardButton.WithCallbackData("Molodoy", "Molodoy"),
                    InlineKeyboardButton.WithCallbackData("Sidde", "Sidde")

                    }
            }));

        break;

        case "/jogos":

            await  bot.SendMessage(msg.Chat, "🎮 Ultimos Jogos e Futuros:");

            var options = new RestClientOptions("https://api.pandascore.co/teams/124530/matches?range[begin_at]=2025-01-01T00:00:00Z,2025-12-31T23:59:59Z&token=9zt1QfOPrI_wT-JBR6rinvQjmnwMBFXhUtzWUNGRRKqpV9c_l94");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("authorization", "Bearer 9zt1QfOPrI_wT-JBR6rinvQjmnwMBFXhUtzWUNGRRKqpV9c_l94");
            var response = await client.GetAsync(request);

            dynamic matches = JsonConvert.DeserializeObject(response.Content);
            int cont = 0;
            int limite = 5;

            
            
            foreach (var match in matches)
            {
              if (cont == limite)
              break;

              bot.SendMessage(msg.Chat, $"🆚 Partida: { match.name}\n📅 Data e Hora: {match.begin_at}\n🏆 Vencedor: {match.winner?.name}" );

              cont ++;
            }

        break;

        case "/menu":
        {
            bot.SendMessage(msg.Chat, "🔥 Bem-vindo ao menu da Nação FURIA!\n\nVocê quer ir além como fã? Então escolha uma opção e mergulhe no universo da FURIA:\n\n🎯 Quer treinar com os melhores?\nDigite /treinar e receba conselhos e treinos exclusivos dos nossos ídolos no CS2!\n\n📅 Quer saber quando será o próximo show da FURIA?\nDigite /jogos e fique por dentro dos próximos confrontos!\n\nÉ só mandar o comando e vamos juntos nessa jornada insana! 🐾🔥");

        break;   
        
        }


    }

}
async Task OnUpdate(Update update, Message msg)
{
    if (update is { CallbackQuery: { } query }) // non-null CallbackQuery
    {
        var escolhido = update.CallbackQuery.Data;
        var chatId = update.CallbackQuery.Message.Chat.Id;
        await bot.SendMessage(chatId, $"Agora que você escolheu o {escolhido}, vamos juntos rumo à evolução no CS2! 🚀 Com a experiência de um dos maiores nomes do cenário, você está mais perto de alcançar o topo!  O que você quer aprimorar? 💥.");

        var pergunta = msg.Text;
        var resposta = await chatService.PergunteAoTreinador(escolhido, pergunta);
        await bot.SendMessage(chatId, resposta);
    }
}



