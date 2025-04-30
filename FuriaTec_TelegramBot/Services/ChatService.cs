using OpenAI.Chat;
using OpenAI;
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuriaTec_TelegramBot.Services
{
    public class ChatService
    {
        public async Task<string> PergunteAoTreinador(string treinador, string pergunta)
        {
            string key = "100588850867037024860_1035c8b13f285ed0";
            string model = "sabiazinho-3";
            string url = "https://chat.maritaca.ai/api";
            string nameProject = "ExemploUsandoMaritaca";

            ApiKeyCredential apiKeyCredential = new ApiKeyCredential(key);

            OpenAIClientOptions openAIClientOptions = new OpenAIClientOptions
            {
                Endpoint = new Uri(url),
                OrganizationId = nameProject,
                ProjectId = nameProject
            };

            ChatClient chatClient = new ChatClient(model, apiKeyCredential, openAIClientOptions);

            ChatCompletionOptions chatOptions = new ChatCompletionOptions
            {
                Temperature = 0.7f,
            };

            List<ChatMessage> chatMessages = new List<ChatMessage>();

            UserChatMessage userChat = ChatMessage.CreateUserMessage($"Você é o treinador: {treinador}, responda como se fosse ele, jogador profissional da FURIA, falando com um fã de forma motivacional e técnica sobre CS:GO, RESPONDA A PERGUNTA DE MANEIRA CLARA: {pergunta}");
            chatMessages.Add(userChat);

            ChatCompletion chatCompletion = await chatClient.CompleteChatAsync(chatMessages, chatOptions);

            AssistantChatMessage assistant = ChatMessage.CreateAssistantMessage(chatCompletion.Content[0].Text);
            string assistantResponse = assistant.Content[0].Text;
            chatMessages.Add(assistant);


            return assistantResponse;

        }

    }
}
