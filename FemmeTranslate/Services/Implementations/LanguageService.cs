using System.Collections.Generic;
using FemmeTranslate.Services.Abstractions;

namespace FemmeTranslate.Services.Implementations
{
    public class LanguageService : ILanguageService
    {
        private static readonly (string Code, string Display)[] _langs = new[]
        {
            ("auto", "Auto"),
            ("es", "Español"),
            ("en", "Inglés"),
            ("fr", "Francés"),
            ("de", "Alemán"),
            ("it", "Italiano"),
            ("pt", "Portugués"),
            ("ru", "Ruso"),
            ("ja", "Japonés"),
            ("zh", "Chino")
        };

        public IReadOnlyList<(string Code, string Display)> GetSupported() => _langs;
    }
}
