using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FemmeTranslate.Services.Abstractions;
using FemmeTranslate.Utilities;
using FemmeTranslate.Utilities.Http;

namespace FemmeTranslate.Services.Implementations
{
    public class MyMemoryService
    {
        private readonly ApiClientFactory _factory;
        public MyMemoryService(ApiClientFactory factory) => _factory = factory;

        public async Task<Result<string>> TranslateAsync(string text, string source, string target, CancellationToken ct)
        {
            try
            {
                var client = _factory.Create("MyMemory");
                var url = $"get?q={Uri.EscapeDataString(text)}&langpair={source}|{target}";
                using var resp = await client.GetAsync(url, ct).ConfigureAwait(false);
                resp.EnsureSuccessStatusCode();
                using var stream = await resp.Content.ReadAsStreamAsync(ct).ConfigureAwait(false);
                using var doc = await JsonDocument.ParseAsync(stream, cancellationToken: ct).ConfigureAwait(false);
                var translated = doc.RootElement.GetProperty("responseData").GetProperty("translatedText").GetString();
                return Result<string>.Success(translated ?? string.Empty);
            }
            catch (OperationCanceledException)
            {
                return Result<string>.Failure("Operación cancelada");
            }
            catch (HttpRequestException ex)
            {
                return Result<string>.Failure(ex.Message);
            }
        }
    }
}
