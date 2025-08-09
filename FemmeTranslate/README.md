# FemmeTranslate

FemmeTranslate es una aplicación de ejemplo en Windows Forms (.NET 9) que traduce texto utilizando [LibreTranslate](https://libretranslate.com/) con un *fallback* a [MyMemory](https://mymemory.translated.net/).

La interfaz tiene un estilo femenino suave y moderno.

## Cómo compilar y ejecutar

1. Requiere .NET 9 SDK (o compatible) en Windows.
2. `dotnet build`
3. `dotnet run --project FemmeTranslate`

## Idiomas soportados

- Español (`es`)
- Inglés (`en`)
- Francés (`fr`)
- Alemán (`de`)
- Italiano (`it`)
- Portugués (`pt`)
- Ruso (`ru`)
- Japonés (`ja`)
- Chino (`zh`)

## Notas de TTS

Se utiliza `System.Speech.Synthesis.SpeechSynthesizer`. La voz femenina depende de lo instalado en el sistema.

## Endpoints públicos

Los endpoints usados son públicos y pueden tener límites de uso o disponibilidad.
