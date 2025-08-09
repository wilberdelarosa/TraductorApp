using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using FemmeTranslate.Models;
using FemmeTranslate.Services.Abstractions;
using FemmeTranslate.Utilities;

namespace FemmeTranslate.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ITranslatorService _translator;
        private readonly ITextToSpeechService _tts;
        public event PropertyChangedEventHandler? PropertyChanged;

        public BindingList<TranslationResult> History { get; } = new();

        private string _sourceText = string.Empty;
        public string SourceText
        {
            get => _sourceText;
            set { _sourceText = value; OnChanged(nameof(SourceText)); }
        }

        private string _targetText = string.Empty;
        public string TargetText
        {
            get => _targetText;
            private set { _targetText = value; OnChanged(nameof(TargetText)); }
        }

        private string _sourceLang = "auto";
        public string SourceLang
        {
            get => _sourceLang;
            set { _sourceLang = value; OnChanged(nameof(SourceLang)); }
        }

        private string _targetLang = "en";
        public string TargetLang
        {
            get => _targetLang;
            set { _targetLang = value; OnChanged(nameof(TargetLang)); }
        }

        private bool _isTranslating;
        public bool IsTranslating
        {
            get => _isTranslating;
            private set { _isTranslating = value; OnChanged(nameof(IsTranslating)); }
        }

        public MainViewModel(ITranslatorService translator, ITextToSpeechService tts)
        {
            _translator = translator;
            _tts = tts;
        }

        public async Task TranslateAsync(CancellationToken ct)
        {
            if (string.IsNullOrWhiteSpace(SourceText) || SourceLang == TargetLang)
                return;
            IsTranslating = true;
            var result = await _translator.TranslateAsync(SourceText, SourceLang, TargetLang, ct).ConfigureAwait(false);
            IsTranslating = false;
            if (result.IsSuccess && result.Value is { } text)
            {
                TargetText = text;
                var entry = new TranslationResult(SourceText, text, SourceLang, TargetLang);
                History.Insert(0, entry);
                while (History.Count > 10) History.RemoveAt(10);
            }
        }

        public void SwapLanguages()
        {
            var tmp = SourceLang;
            SourceLang = TargetLang;
            TargetLang = tmp;
        }

        public void Clear()
        {
            SourceText = string.Empty;
            TargetText = string.Empty;
        }

        public void CopyResult()
        {
            if (!string.IsNullOrEmpty(TargetText))
                System.Windows.Forms.Clipboard.SetText(TargetText);
        }

        public async Task SpeakResultAsync(CancellationToken ct)
        {
            if (!string.IsNullOrEmpty(TargetText))
                await _tts.SpeakAsync(TargetText, TargetLang, true, ct).ConfigureAwait(false);
        }

        private void OnChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
