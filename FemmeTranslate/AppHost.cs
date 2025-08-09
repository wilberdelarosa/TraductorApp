using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using FemmeTranslate.Forms;
using FemmeTranslate.ViewModels;
using FemmeTranslate.Services.Abstractions;
using FemmeTranslate.Services.Implementations;
using FemmeTranslate.Utilities.Http;

namespace FemmeTranslate
{
    internal static class AppHost
    {
        public static IHost Build(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                {
                    services.AddSingleton<MainForm>();
                    services.AddSingleton<SettingsForm>();
                    services.AddSingleton<MainViewModel>();

                    services.AddSingleton<ILanguageService, LanguageService>();
                    services.AddHttpClient("Libre", c =>
                    {
                        c.BaseAddress = new Uri("https://libretranslate.com/");
                        c.Timeout = TimeSpan.FromSeconds(15);
                    });
                    services.AddHttpClient("MyMemory", c =>
                    {
                        c.BaseAddress = new Uri("https://api.mymemory.translated.net/");
                        c.Timeout = TimeSpan.FromSeconds(15);
                    });
                    services.AddSingleton<ApiClientFactory>();
                    services.AddTransient<MyMemoryService>();
                    services.AddTransient<ITranslatorService, LibreTranslateService>();
                    services.AddTransient<ITextToSpeechService, WindowsTtsService>();
                })
                .Build();
    }
}
