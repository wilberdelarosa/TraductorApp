using System;
using System.Linq;
using System.Speech.Synthesis;
using System.Threading;
using System.Threading.Tasks;
using FemmeTranslate.Services.Abstractions;
using FemmeTranslate.Utilities;

namespace FemmeTranslate.Services.Implementations
{
    public class WindowsTtsService : ITextToSpeechService
    {
        public async Task<Result<bool>> SpeakAsync(string text, string? languageCode, bool preferFemale, CancellationToken ct)
        {
            try
            {
                using var synth = new SpeechSynthesizer();
                var voices = synth.GetInstalledVoices()
                    .Where(v => languageCode == null || v.VoiceInfo.Culture.TwoLetterISOLanguageName == languageCode);
                var voice = voices.FirstOrDefault(v => !preferFemale || v.VoiceInfo.Gender == VoiceGender.Female) ?? voices.FirstOrDefault();
                if (voice != null)
                {
                    synth.SelectVoice(voice.VoiceInfo.Name);
                }
                synth.SpeakCompleted += (_, __) => synth.Dispose();
                await Task.Run(() => synth.Speak(text), ct).ConfigureAwait(false);
                return Result<bool>.Success(true);
            }
            catch (OperationCanceledException)
            {
                return Result<bool>.Failure("Cancelado");
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure(ex.Message);
            }
        }
    }
}
