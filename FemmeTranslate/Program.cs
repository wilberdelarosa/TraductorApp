using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FemmeTranslate
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using IHost host = AppHost.Build(args);
            ApplicationConfiguration.Initialize();
            var mainForm = host.Services.GetRequiredService<Forms.MainForm>();
            Application.Run(mainForm);
        }
    }
}
