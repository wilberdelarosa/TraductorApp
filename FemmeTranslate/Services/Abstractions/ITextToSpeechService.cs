using System.Threading;
using System.Threading.Tasks;
using FemmeTranslate.Utilities;

namespace FemmeTranslate.Services.Abstractions
{
    public interface ITextToSpeechService
    {
        Task<Result<bool>> SpeakAsync(string text, string? languageCode, bool preferFemale, CancellationToken ct);
    }
}
