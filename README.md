📦 YouTube Video Downloader Console App

Este é um projeto de Console App em C# (.NET 8) que permite baixar vídeos do YouTube em MP4, com áudio e vídeo mesclados. O projeto utiliza yt-dlp para download e ffmpeg para mesclar áudio e vídeo, exibindo uma barra de progresso fiel diretamente no console.

🚀 Tecnologias Utilizadas

.NET 8
 – plataforma principal

C#
 – linguagem principal

yt-dlp
 – download de vídeos do YouTube

FFmpeg
 – mescla de áudio + vídeo

Console App – interface simples e direta

🧱 Estrutura do Projeto
ConsoleApp1/
├── Patch/                 # Contém yt-dlp.exe e ffmpeg.exe (não versionada no GitHub)
├── Program.cs             # Código principal do Console App
├── ConsoleApp1.csproj
└── downloads/             # Pasta onde os vídeos baixados serão salvos


⚠️ Patch: Cada usuário deve baixar os executáveis yt-dlp.exe e ffmpeg.exe e colocar nesta pasta. Ela não está versionada no GitHub.

🔐 Segurança e Boas Práticas

Uso legal: Apenas faça download de vídeos que você tem direito de acessar.

Sem binários no repositório: yt-dlp e ffmpeg não estão incluídos, evitando problemas de tamanho e licenciamento.

Código limpo e extensível: Fácil de adaptar para playlists, downloads de áudio, ou integração em outros projetos.

📄 Principais Funcionalidades

✅ Baixa vídeos do YouTube em MP4 com áudio + vídeo mesclados

✅ Barra de progresso visual e fiel a 100%

✅ Detecta automaticamente yt-dlp e ffmpeg na pasta Patch

✅ Mensagens informativas de extração, download e merge

✅ Cria a pasta downloads automaticamente para armazenar os vídeos

⚡ Como Usar

Baixe yt-dlp.exe e ffmpeg.exe e coloque na pasta Patch/.

Compile e execute o projeto:

dotnet run


Cole a URL do vídeo do YouTube quando solicitado:

🔗 Cole a URL do YouTube: https://www.youtube.com/watch?v=dQw4w9WgXcQ


Acompanhe o progresso no console.

O vídeo será salvo automaticamente na pasta downloads/.

💡 Possíveis Melhorias Futuras

Suporte a playlists completas

Opção para baixar apenas áudio (MP3)

Exibição de ETA e velocidade mais detalhada

Cancelamento de downloads via console