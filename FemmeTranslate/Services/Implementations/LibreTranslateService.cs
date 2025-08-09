using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FemmeTranslate.Services.Abstractions;
using FemmeTranslate.Utilities;
using FemmeTranslate.Utilities.Http;

namespace FemmeTranslate.Services.Implementations
{
    public class LibreTranslateService : ITranslatorService
    {
        private readonly ApiClientFactory _factory;
        private readonly MyMemoryService _fallback;
        public LibreTranslateService(ApiClientFactory factory, MyMemoryService fallback)
        {
            _factory = factory;
            _fallback = fallback;
        }

        public async Task<Result<string>> TranslateAsync(string text, string source, string target, CancellationToken ct)
        {
            try
            {
                var client = _factory.Create("Libre");
                var payload = new { q = text, source = source, target = target, format = "text" };
                using var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
                using var resp = await client.PostAsync("translate", content, ct).ConfigureAwait(false);
                resp.EnsureSuccessStatusCode();
                using var stream = await resp.Content.ReadAsStreamAsync(ct).ConfigureAwait(false);
                using var doc = await JsonDocument.ParseAsync(stream, cancellationToken: ct).ConfigureAwait(false);
                var translated = doc.RootElement.GetProperty("translatedText").GetString();
                return Result<string>.Success(translated ?? string.Empty);
            }
            catch (OperationCanceledException)
            {
                return Result<string>.Failure("Operación cancelada");
            }
            catch (Exception)
            {
                return await _fallback.TranslateAsync(text, source, target, ct).ConfigureAwait(false);
            }
        }
    }
}
