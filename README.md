# 📦 YouTube Video Downloader Console App

Este é um projeto de **Console App em C# (.NET 8)** que permite baixar vídeos do **YouTube** em **MP4** com áudio e vídeo mesclados. O projeto utiliza **yt-dlp** para download e **ffmpeg** para mesclar o áudio e vídeo, exibindo uma **barra de progresso** fiel diretamente no console.

---

## 🛠 Pré-requisitos
### yt-dlp
Baixe o executável mais recente: [yt-dlp Releases](https://github.com/yt-dlp/yt-dlp/releases) 
Coloque o arquivo yt-dlp.exe na pasta Patch do projeto:
```
TubeLoad/Patch/yt-dlp.exe
```

### FFmpeg
Baixe o build completo: [FFmpeg Builds](https://www.gyan.dev/ffmpeg/builds/) 
Extraia o conteúdo do .zip ou .7z dentro dessa pasta.
Depois de extrair, a estrutura deve ficar assim: 
```
C:\ffmpeg\ffmpeg-6.0-full_build\bin\ffmpeg.exe
```
Coloque ffmpeg.exe na mesma pasta Patch:
```
TubeLoad/Patch/ffmpeg.exe
TubeLoad/Patch/ffplay.exe
TubeLoad/Patch/ffprobe.exe
```
⚠️ Importante: o GitHub não deve conter a pasta Patch com executáveis. Ela está ignorada no .gitignore. Cada usuário deve baixar os executáveis separadamente.

## 🧱 Arquitetura do Projeto
```
TubeLoad/
├── Patch # <- Contém yt-dlp.exe e ffmpeg.exe (não versionada no GitHub)
├── Program.cs #  <- Código principal
├── TubeLoad.csproj
├── downloads #  <- Pasta onde os vídeos baixados serão salvos
```
⚠️ Patch: Cada usuário deve baixar os executáveis yt-dlp.exe e ffmpeg.exe e colocar nesta pasta. Ela não está versionada no GitHub.

---

## ⚡ Como usar

- Abra o projeto no Visual Studio ou VS Code.
- Cole a URL do vídeo do YouTube quando solicitado:```🔗 Cole a URL do YouTube: https://www.youtube.com/watch?v=dQw4w9WgXcQ```
- O download começará e mostrará o progresso em tempo real.
- Ao finalizar, o vídeo será salvo na pasta downloads.

---

## 📄 Funcionalidades

- ✅ Baixa vídeos do YouTube em MP4 com áudio + vídeo mesclados.
- ✅ Detecta yt-dlp.exe e ffmpeg.exe na pasta Patch.
- ✅ Mostra barra de progresso fiel a 100% no console.
- ✅ Salva vídeos na pasta downloads automaticamente.

---
Desenvolvido por Kauê Correia
