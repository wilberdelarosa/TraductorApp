using System.Threading;
using System.Threading.Tasks;
using FemmeTranslate.Utilities;

namespace FemmeTranslate.Services.Abstractions
{
    public interface ITranslatorService
    {
        Task<Result<string>> TranslateAsync(string text, string source, string target, CancellationToken ct);
    }
}
