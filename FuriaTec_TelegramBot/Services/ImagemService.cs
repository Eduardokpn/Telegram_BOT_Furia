using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuriaTec_TelegramBot.Services
{
    public class ImagemService
    {
        public async Task<string> GerarImagem(string nome)
        {
            var caminhoOriginal = "C:/Users/eduar/OneDrive/Documentos/Projetos/FuriaTec_TelegramBot/FuriaTec_TelegramBot/Resources/certificadoFuria.png";
            var caminhoFinal = Path.Combine(Path.GetTempPath(), $"card_furia_{nome}.png");

            using var imagem = await Image.LoadAsync<Rgba32>(caminhoOriginal);
            var fonteCollection = new FontCollection();
            var font = SystemFonts.CreateFont("Arial", 55);
            var estilo = new Font(font, 55, FontStyle.Regular);

            imagem.Mutate(ctx => ctx.DrawText(nome, estilo, SixLabors.ImageSharp.Color.Gold, new PointF(170, 200)));

            await imagem.SaveAsync(caminhoFinal);
            return caminhoFinal;

        }
    }
}
