using System.Collections.Generic;

namespace FemmeTranslate.Services.Abstractions
{
    public interface ILanguageService
    {
        IReadOnlyList<(string Code, string Display)> GetSupported();
    }
}
